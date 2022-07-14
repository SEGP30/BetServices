using System;
using System.Linq;
using System.Threading.Tasks;
using BetServices.Application.BetServices.Requests;
using BetServices.Application.BetServices.Responses;
using BetServices.Application.ClientServices;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Domain.Enums;

namespace BetServices.Application.BetServices
{
    public class PlaceBetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaceBetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlaceBetResponse> Execute(PlaceBetRequest request)
        {
            var openRoulette = (await _unitOfWork.RouletteRepository.FindBy(r => r.Id ==
                request.RouletteId && r.State == RouletteState.Open)).FirstOrDefault();
            if(openRoulette == null)
                return new PlaceBetResponse
                {
                    Message = "Cannot place a bet in this roulette"
                };
            
            var clientInDb = await _unitOfWork.ClientRepository.Find(request.ClientId);
            if (clientInDb == null)
                return new PlaceBetResponse
                {
                    Message = "This client doesn't exists"
                };
            
            if(clientInDb.Credit < request.Amount)
                return new PlaceBetResponse
                {
                    Message = "There is no enough credit to place this bet"
                };
            
            if(request.Amount > 10000)
                return new PlaceBetResponse
                {
                    Message = "Bet's amount to place has been surpassed"
                };

            var betToPlace = new Bet
            {
                RouletteId = request.RouletteId,
                ClientId = request.ClientId,
                Amount = request.Amount,
                Type = request.BetType,
                CreationDate = DateTime.Today,
                EntityState = EntityState.Active,
                SelectedColor = request.BetType != BetType.Color ? null : request.SelectedColor,
                SelectedNumber = request.BetType != BetType.Numerical ? null : request.SelectedNumber,
                UpdateTime = DateTime.Now
            };

            await new PayBetService(_unitOfWork).Execute(betToPlace.ClientId, betToPlace.Amount);
            await _unitOfWork.BetRepository.Insert(betToPlace);
            await _unitOfWork.Commit();
            
            return new PlaceBetResponse
            {
                Message = "Bet has been placed"
            };
        }
    }
}
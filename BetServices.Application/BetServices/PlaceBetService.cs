using System;
using System.Linq;
using System.Threading.Tasks;
using BetServices.Application.BetServices.Requests;
using BetServices.Application.BetServices.Responses;
using BetServices.Application.ClientServices;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Domain.Enums;
using BetServices.Domain.Exceptions;

namespace BetServices.Application.BetServices
{
    public class PlaceBetService
    {
        private readonly PayBetService _payBetService;
        private readonly IBetRepository _betRepository;
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IClientRepository _clientRepository;

        public PlaceBetService(PayBetService payBetService, IBetRepository betRepository, 
            IRouletteRepository rouletteRepository, IClientRepository clientRepository)
        {
            _payBetService = payBetService;
            _betRepository = betRepository;
            _rouletteRepository = rouletteRepository;
            _clientRepository = clientRepository;
        }

        public async Task<PlaceBetResponse> Execute(PlaceBetRequest request)
        {
            var openRoulette = await _rouletteRepository.FindOpenRoulette(request.RouletteId);
            if (openRoulette == null)
                throw new UnnoperativeRouletteException();

            var clientInDb = await _clientRepository.Find(request.ClientId);
            if (clientInDb == null)
                throw new ClientNotFoundException();

            if (request.Amount <= 0)
                throw new NegativeOrZeroAmountException();

            if (clientInDb.Credit < request.Amount)
                throw new NotEnoughCreditException();

            if (request.Amount > 10000)
                throw new AmountSurpassedException();

            if (request.SelectedNumber > 36)
                throw new RangeOfNumbersSurpassedException();

            var betToPlace = new Bet
            {
                RouletteId = request.RouletteId,
                ClientId = request.ClientId,
                Amount = request.Amount,
                Type = request.BetType,
                CreationDate = DateTime.Today,
                EntityState = EntityState.Active,
                SelectedColor = request.BetType != BetType.Color ? (SelectedColor?) null : request.SelectedColor,
                SelectedNumber = request.BetType != BetType.Numerical ? (short) 0 : request.SelectedNumber,
                UpdateTime = DateTime.Now
            };

            await _payBetService.Execute(betToPlace.ClientId, betToPlace.Amount);
            await _betRepository.Insert(betToPlace);
            //await _unitOfWork.Commit();
            
            return new PlaceBetResponse
            {
                Message = "Bet has been placed"
            };
        }
    }
}
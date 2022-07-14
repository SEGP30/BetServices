using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetServices.Application.BetServices.Requests;
using BetServices.Application.BetServices.Responses;
using BetServices.Application.ClientServices;
using BetServices.Application.RouletteServices;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Domain.Enums;

namespace BetServices.Application.BetServices
{
    public class ClosingBetsService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ClosingBetsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<ClosingBetsResponse> Execute(long rouletteId)
        {
            var winnerNumber = new Random().Next(37);
            var closedRoulette = await new RouletteClosingService(_unitOfWork).Execute(rouletteId);
            if (!closedRoulette.Response)
                return new ClosingBetsResponse
                {
                    Bets = new List<Bet>()
                };

            var betsToClose = await _unitOfWork.BetRepository.FindBy(b => b.RouletteId == rouletteId);
            betsToClose.ForEach(b => b.EntityState = EntityState.Inactive);
            betsToClose.ForEach(b => b.Reward = b.Type != BetType.Color && b.SelectedNumber == winnerNumber ? 
                b.Amount * 5 : 0);
            betsToClose.ForEach(b => b.Reward = (long)(b.Type != BetType.Numerical && b.SelectedColor == SelectedColor.Red 
                && winnerNumber % 2 == 0 ? b.Amount * 1.8 : 0));
            betsToClose.ForEach(b => b.Reward = (long)(b.Type != BetType.Numerical && b.SelectedColor == SelectedColor.Black 
                && winnerNumber % 2 == 1 ? b.Amount * 1.8 : 0));
 
            _unitOfWork.BetRepository.UpdateRange(betsToClose);
            await _unitOfWork.Commit();
            
            betsToClose.ForEach(async b =>  await new ObtainRewardService(_unitOfWork).Execute(b));

            return new ClosingBetsResponse
            {
                Bets = betsToClose
            };

        }
    }
}
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
        private readonly RouletteClosingService _rouletteClosingService;
        private readonly ObtainRewardService _obtainRewardService;


        public ClosingBetsService(IUnitOfWork unitOfWork, RouletteClosingService rouletteClosingService, ObtainRewardService obtainRewardService)
        {
            _unitOfWork = unitOfWork;
            _rouletteClosingService = rouletteClosingService;
            _obtainRewardService = obtainRewardService;
        }

        public async Task<ClosingBetsResponse> Execute(long rouletteId)
        {
            var winnerNumber = new Random().Next(37);
            var closedRoulette = await  _rouletteClosingService.Execute(rouletteId);
            if (!closedRoulette.Response)
                return new ClosingBetsResponse
                {
                    Bets = new List<Bet>()
                };

            var betsToClose = await _unitOfWork.BetRepository.FindBy(b => b.RouletteId == rouletteId);

            foreach (var bet in betsToClose)
            {
                bet.EntityState = EntityState.Inactive; 
                bet.CalculateReward(winnerNumber);
            }
            
            _unitOfWork.BetRepository.UpdateRange(betsToClose);
            await _unitOfWork.Commit();
            
            betsToClose.ForEach(async b =>  await _obtainRewardService.Execute(b));

            return new ClosingBetsResponse
            {
                Bets = betsToClose
            };

        }
    }
}
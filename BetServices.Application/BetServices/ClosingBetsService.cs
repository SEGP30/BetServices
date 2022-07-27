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
        private readonly RouletteClosingService _rouletteClosingService;
        private readonly ObtainRewardService _obtainRewardService;
        private readonly IBetRepository _betRepository;


        public ClosingBetsService(RouletteClosingService rouletteClosingService, 
            ObtainRewardService obtainRewardService, IBetRepository betRepository)
        {
   
            _rouletteClosingService = rouletteClosingService;
            _obtainRewardService = obtainRewardService;
            _betRepository = betRepository;
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

            var betsToClose = await _betRepository.FindActiveBetsByRouletteId(rouletteId);

            foreach (var bet in betsToClose)
            {
                bet.EntityState = EntityState.Inactive; 
                bet.CalculateReward(winnerNumber);
                bet.UpdateTime = DateTime.Now;
                await _betRepository.Update(bet);
            }
            
            //_betRepository.UpdateRange(betsToClose);
            //await _unitOfWork.Commit();
            
            betsToClose.ForEach(async b =>  await _obtainRewardService.Execute(b));

            return new ClosingBetsResponse
            {
                Bets = betsToClose
            };

        }
    }
}
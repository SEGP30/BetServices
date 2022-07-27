using System;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;

namespace BetServices.Application.ClientServices
{
    public class ObtainRewardService
    {
        private readonly IClientRepository _clientRepository;

        public ObtainRewardService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Execute(Bet bet)
        {
            var clientInDb = await _clientRepository.Find(bet.ClientId);

            clientInDb.Credit += bet.Reward;
            clientInDb.UpdateTime = DateTime.Now;
            await _clientRepository.Update(clientInDb);
            //await _unitOfWork.Commit();
        }
        
    }
}
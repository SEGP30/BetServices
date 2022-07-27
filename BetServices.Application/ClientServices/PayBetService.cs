using System;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;

namespace BetServices.Application.ClientServices
{
    public class PayBetService
    {

        private readonly IClientRepository _clientRepository;

        public PayBetService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Execute(long clientId, short amountToPay)
        {
            var clientInDb = await _clientRepository.Find(clientId);

            clientInDb.Credit -= amountToPay;
            clientInDb.UpdateTime = DateTime.Now;
            await _clientRepository.Update(clientInDb);
            //await _unitOfWork.Commit();
            
        }
    }
}
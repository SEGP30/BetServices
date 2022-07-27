using System;
using System.Threading.Tasks;
using BetServices.Application.ClientServices.Requests;
using BetServices.Application.ClientServices.Responses;
using BetServices.Domain.Contracts;

namespace BetServices.Application.ClientServices
{
    public class DepositCreditService
    {
        private readonly IClientRepository _clientRepository;

        public DepositCreditService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<DepositCreditResponse> Execute(DepositCreditRequest request)
        {
            var clientToDeposit = await _clientRepository.Find(request.ClientId);
            if (clientToDeposit == null)
                return new DepositCreditResponse
                {
                    Message = "No Client found with this Id"
                };
            
            if (request.NewCredit <= 0)
                return new DepositCreditResponse
                {
                    Message = "Cannot deposit negative or 0 credit"
                };

            clientToDeposit.Credit += request.NewCredit;
            clientToDeposit.UpdateTime = DateTime.Now;
            await _clientRepository.Update(clientToDeposit);
            //await _unitOfWork.Commit();
            
            return new DepositCreditResponse
            {
                Message = "Client's credit has been updated"
            };

        }
    }
}
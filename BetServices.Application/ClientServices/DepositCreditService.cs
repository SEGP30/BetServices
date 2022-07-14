using System;
using System.Threading.Tasks;
using BetServices.Application.ClientServices.Requests;
using BetServices.Application.ClientServices.Responses;
using BetServices.Domain.Contracts;

namespace BetServices.Application.ClientServices
{
    public class DepositCreditService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepositCreditService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DepositCreditResponse> Execute(DepositCreditRequest request)
        {
            var clientToDeposit = await _unitOfWork.ClientRepository.Find(request.ClientId);
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

            clientToDeposit.Credit = request.NewCredit;
            clientToDeposit.UpdateTime = DateTime.Now;
            _unitOfWork.ClientRepository.Update(clientToDeposit);
            await _unitOfWork.Commit();
            
            return new DepositCreditResponse
            {
                Message = "Client's credit has been updated"
            };

        }
    }
}
using System;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;

namespace BetServices.Application.ClientServices
{
    public class PayBetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayBetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long clientId, short amountToPay)
        {
            var clientInDb = await _unitOfWork.ClientRepository.Find(clientId);

            clientInDb.Credit -= amountToPay;
            clientInDb.UpdateTime = DateTime.Now;
            _unitOfWork.ClientRepository.Update(clientInDb);
            await _unitOfWork.Commit();
            
        }
    }
}
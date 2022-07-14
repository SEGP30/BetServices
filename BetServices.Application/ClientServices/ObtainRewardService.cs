using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;

namespace BetServices.Application.ClientServices
{
    public class ObtainRewardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtainRewardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Bet bet)
        {
            var clientIDb = await _unitOfWork.ClientRepository.Find(bet.ClientId);

            clientIDb.Credit += bet.Reward;
            _unitOfWork.ClientRepository.Update(clientIDb);
            await _unitOfWork.Commit();
        }
        
    }
}
using System.Linq;
using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Enums;

namespace BetServices.Application.RouletteServices
{
    public class RouletteClosingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouletteClosingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RouletteClosingResponse> Execute(long rouletteId)
        {
            var rouletteToClose = (await _unitOfWork.RouletteRepository.FindBy(r => r.Id ==
                rouletteId && r.State == RouletteState.Open)).FirstOrDefault();
            if(rouletteToClose == null)
                return new RouletteClosingResponse
                {
                    Response = false
                };
            
            rouletteToClose.State = RouletteState.Closed;
            
            _unitOfWork.RouletteRepository.Update(rouletteToClose);
            await _unitOfWork.Commit();
            
            return new RouletteClosingResponse
            {
                Response = true
            };
        }
    }
}
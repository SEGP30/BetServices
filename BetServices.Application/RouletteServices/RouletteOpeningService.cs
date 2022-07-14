using System.Linq;
using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Requests;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Enums;

namespace BetServices.Application.RouletteServices
{
    public class RouletteOpeningService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouletteOpeningService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RouletteOpeningResponse> Execute(RouletteOpeningRequest request)
        {
            var rouletteToOpen = await _unitOfWork.RouletteRepository.Find(request.RouletteId);
            if (rouletteToOpen == null)
                return new RouletteOpeningResponse
                {
                    Message = "Operation denied"
                };

            rouletteToOpen.State = RouletteState.Open;
            
            _unitOfWork.RouletteRepository.Update(rouletteToOpen);
            await _unitOfWork.Commit();

            return new RouletteOpeningResponse
            {
                Message = "Operation succeed"
            };
        }
    }
}
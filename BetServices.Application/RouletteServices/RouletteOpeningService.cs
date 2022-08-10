using System.Linq;
using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Requests;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Enums;
using BetServices.Domain.Exceptions;

namespace BetServices.Application.RouletteServices
{
    public class RouletteOpeningService
    {
        private readonly IRouletteRepository _rouletteRepository;

        public RouletteOpeningService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public async Task<RouletteOpeningResponse> Execute(RouletteOpeningRequest request)
        {
            var rouletteToOpen = await _rouletteRepository.FindUnnoperativeRoulette(request.RouletteId);
            if (rouletteToOpen == null)
                throw new RouletteNotFoundException();

            rouletteToOpen.State = RouletteState.Open;
            
            await _rouletteRepository.Update(rouletteToOpen);
            //await _unitOfWork.Commit();

            return new RouletteOpeningResponse
            {
                Message = "Operation succeed"
            };
        }
    }
}
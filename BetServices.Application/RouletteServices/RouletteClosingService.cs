using System.Linq;
using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Enums;

namespace BetServices.Application.RouletteServices
{
    public class RouletteClosingService
    {
        private readonly IRouletteRepository _rouletteRepository;

        public RouletteClosingService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public async Task<RouletteClosingResponse> Execute(long rouletteId)
        {
            var rouletteToClose = await _rouletteRepository.FindOpenRoulette(rouletteId);
            if(rouletteToClose == null)
                return new RouletteClosingResponse
                {
                    Response = false
                };
            
            rouletteToClose.State = RouletteState.Closed;
            
            await _rouletteRepository.Update(rouletteToClose);
            //await _unitOfWork.Commit();
            
            return new RouletteClosingResponse
            {
                Response = true
            }; 
        }
    }
}
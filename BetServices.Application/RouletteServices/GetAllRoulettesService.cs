using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;

namespace BetServices.Application.RouletteServices
{
    public class GetAllRoulettesService
    {
        private readonly IRouletteRepository _rouletteRepository;

        public GetAllRoulettesService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public async Task<GetAllRoulettesResponse> Execute()
        {
            var allRoulettes = await _rouletteRepository.FindAll();

            return new GetAllRoulettesResponse
            {
                Roulettes = allRoulettes
            };
        }
    }
}
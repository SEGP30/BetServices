using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;

namespace BetServices.Application.RouletteServices
{
    public class GetAllRoulettesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoulettesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllRoulettesResponse> Execute()
        {
            var allRoulettes = await _unitOfWork.RouletteRepository.FindAll();

            return new GetAllRoulettesResponse
            {
                Roulettes = allRoulettes
            };
        }
    }
}
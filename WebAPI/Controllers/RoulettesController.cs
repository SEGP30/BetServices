using System.Threading.Tasks;
using BetServices.Application.RouletteServices;
using BetServices.Application.RouletteServices.Requests;
using BetServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    
    public class RoulettesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoulettesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("/roulettes")]
        public async Task<IActionResult> RegisterRoulette(CreateRouletteRequest request)
        {
            var service = new CreateRouletteService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("/roulettes/state")]
        public async Task<IActionResult> RouletteOpening(RouletteOpeningRequest request)
        {
            var service = new RouletteOpeningService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/roulettes")]
        public async Task<IActionResult> GetAllRoulettes()
        {
            var service = new GetAllRoulettesService(_unitOfWork);
            var response = await service.Execute();
            return Ok(response);
        }
    }
}
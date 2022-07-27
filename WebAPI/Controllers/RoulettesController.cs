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
        private readonly CreateRouletteService _createRouletteService;
        private readonly RouletteOpeningService _rouletteOpeningService;
        private readonly GetAllRoulettesService _getAllRoulettesService;

        public RoulettesController(CreateRouletteService createRouletteService,
            RouletteOpeningService rouletteOpeningService, GetAllRoulettesService getAllRoulettesService)
        {
            _createRouletteService = createRouletteService;
            _rouletteOpeningService = rouletteOpeningService;
            _getAllRoulettesService = getAllRoulettesService;
        }

        [HttpPost]
        [Route("/roulettes")]
        public async Task<IActionResult> RegisterRoulette(CreateRouletteRequest request)
        {
            var response = await _createRouletteService.Execute(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("/roulettes/state")]
        public async Task<IActionResult> RouletteOpening(RouletteOpeningRequest request)
        {
            var response = await _rouletteOpeningService.Execute(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/roulettes")]
        public async Task<IActionResult> GetAllRoulettes()
        {
            var response = await _getAllRoulettesService.Execute();
            return Ok(response);
        }
    }
}
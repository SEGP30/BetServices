using System.Threading.Tasks;
using BetServices.Application.BetServices;
using BetServices.Application.BetServices.Requests;
using BetServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class BetsController : ControllerBase
    {
        private readonly PlaceBetService _placeBetService;
        private readonly ClosingBetsService _closingBetsService;

        public BetsController(PlaceBetService placeBetService, ClosingBetsService closingBetsService)
        {
            _placeBetService = placeBetService;
            _closingBetsService = closingBetsService;
        }

        //[ApiVersion("1")]
        //[ApiVersion("2")]
        [HttpPost]
        public async Task<IActionResult> PlaceBet(PlaceBetRequest request)
        {
            var response = await _placeBetService.Execute(request);
            return Ok(response);
        }

        //[ApiVersion("2")]
        [HttpGet]
        [Route("close")]
        public async Task<IActionResult> ClosingBets(long rouletteId)
        {
            var response = await _closingBetsService.Execute(rouletteId);
            return Ok(response);
        }
    }
}
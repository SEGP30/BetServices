using System.Threading.Tasks;
using BetServices.Application.BetServices;
using BetServices.Application.BetServices.Requests;
using BetServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    
    public class BetsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("/bets")]
        public async Task<IActionResult> PlaceBet(PlaceBetRequest request)
        {
            var service = new PlaceBetService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/bets/close")]
        public async Task<IActionResult> ClosingBets(long rouletteId)
        {
            var service = new ClosingBetsService(_unitOfWork);
            var response = await service.Execute(rouletteId);
            return Ok(response);
        }
    }
}
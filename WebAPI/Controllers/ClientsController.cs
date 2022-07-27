using System.Threading.Tasks;
using BetServices.Application.ClientServices;
using BetServices.Application.ClientServices.Requests;
using BetServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private readonly RegisterClientService _registerClientService;
        private readonly DepositCreditService _depositCreditService;

        public ClientsController(RegisterClientService registerClientService, DepositCreditService depositCreditService)
        {
            _registerClientService = registerClientService;
            _depositCreditService = depositCreditService;
        }

        [HttpPost]
        [Route("/clients")]
        public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
        {
            var response = await _registerClientService.Execute(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("/clients/credit")]
        public async Task<IActionResult> DepositCredit(DepositCreditRequest request)
        {
            var response = await _depositCreditService.Execute(request);
            return Ok(response);
        }
    }
}
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
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("/clients")]
        public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
        {
            var service = new RegisterClientService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("/clients/credit")]
        public async Task<IActionResult> DepositCredit(DepositCreditRequest request)
        {
            var service = new DepositCreditService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }
    }
}
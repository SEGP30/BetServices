using System;
using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Requests;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Domain.Enums;
using BetServices.Domain.Exceptions;

namespace BetServices.Application.RouletteServices
{
    public class CreateRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;

        public CreateRouletteService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public async Task<CreateRouletteResponse> Execute(CreateRouletteRequest request)
        {
            var rouletteInDb = await _rouletteRepository.Find(request.RouletteId);
            if (rouletteInDb != null)
                throw new RouletteAlreadyExistsException();

            var rouletteToCreate = new Roulette
            {
                Id = request.RouletteId,
                State = RouletteState.Pending,
                EntityState = EntityState.Active,
                CreationDate = DateTime.Today,
                UpdateTime = DateTime.Now
            };

            await _rouletteRepository.Insert(rouletteToCreate);
            //await _unitOfWork.Commit();

            return new CreateRouletteResponse
            {
                ReturnedId = rouletteToCreate.Id
            };
        }
    }
}
using System;
using System.Threading.Tasks;
using BetServices.Application.RouletteServices.Requests;
using BetServices.Application.RouletteServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Domain.Enums;

namespace BetServices.Application.RouletteServices
{
    public class CreateRouletteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRouletteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateRouletteResponse> Execute(CreateRouletteRequest request)
        {
            var rouletteInDb = await _unitOfWork.RouletteRepository.Find(request.RouletteId);
            if (rouletteInDb != null)
                return null;

            var rouletteToCreate = new Roulette
            {
                Id = request.RouletteId,
                State = RouletteState.Pending,
                EntityState = EntityState.Active,
                CreationDate = DateTime.Today,
                UpdateTime = DateTime.Now
            };

            await _unitOfWork.RouletteRepository.Insert(rouletteToCreate);
            await _unitOfWork.Commit();

            return new CreateRouletteResponse
            {
                ReturnedId = rouletteToCreate.Id
            };
        }
    }
}
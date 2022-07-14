using System.Collections.Generic;
using BetServices.Domain.Entities;

namespace BetServices.Application.RouletteServices.Responses
{
    public class GetAllRoulettesResponse
    {
        public IEnumerable<Roulette> Roulettes { get; set; }
    }
}
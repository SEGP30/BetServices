using BetServices.Domain.Base;
using BetServices.Domain.Enums;

namespace BetServices.Domain.Entities
{
    public class Roulette : Entity<long>
    {
        public RouletteState State { get; set; }
    }
}
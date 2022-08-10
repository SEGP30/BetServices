using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class UnnoperativeRouletteException : BetServicesException
    {
        public UnnoperativeRouletteException() : base(HttpStatusCode.NotFound, 
            "Cannot place a bet in this roulette")
        {
        }
    }
}
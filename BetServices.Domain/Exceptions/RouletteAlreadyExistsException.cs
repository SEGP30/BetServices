using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class RouletteAlreadyExistsException : BetServicesException
    {
        public RouletteAlreadyExistsException() : base(HttpStatusCode.Found, "Roulette already exits")
        {
        }
    }
}
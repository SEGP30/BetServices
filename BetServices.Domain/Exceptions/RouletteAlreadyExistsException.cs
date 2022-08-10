using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class RouletteAlreadyExistsException : BetServicesException
    {
        public RouletteAlreadyExistsException() : base(HttpStatusCode.BadRequest, "Roulette already exits")
        {
        }
    }
}
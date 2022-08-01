using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class RouletteNotFoundException : BetServicesException
    {
        public RouletteNotFoundException() : base(HttpStatusCode.NotFound, "Operation denied")
        {
        }
    }
}
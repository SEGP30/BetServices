using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class RangeOfNumbersSurpassedException : BetServicesException
    {
        public RangeOfNumbersSurpassedException() : base(HttpStatusCode.BadRequest, 
            "Cannot choose this number for the bet")
        {
        }
    }
}
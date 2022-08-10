using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class NegativeOrZeroCreditException : BetServicesException
    {
        public NegativeOrZeroCreditException() : base(HttpStatusCode.BadRequest, 
            "Cannot deposit negative or 0 credit")
        {
        }
    }
}
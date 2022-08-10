using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class NegativeOrZeroAmountException : BetServicesException
    {
        public NegativeOrZeroAmountException() : base(HttpStatusCode.BadRequest, 
            "This amount cannot be placed")
        {
        }
    }
}
using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class NegativeOrZeroAmountException : BetServicesException
    {
        public NegativeOrZeroAmountException() : base(HttpStatusCode.PaymentRequired, 
            "This amount cannot be placed")
        {
        }
    }
}
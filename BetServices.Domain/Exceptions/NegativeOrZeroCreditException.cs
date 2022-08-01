using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class NegativeOrZeroCreditException : BetServicesException
    {
        public NegativeOrZeroCreditException() : base(HttpStatusCode.PaymentRequired, 
            "Cannot deposit negative or 0 credit")
        {
        }
    }
}
using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class NotEnoughCreditException : BetServicesException
    {
        public NotEnoughCreditException() : base(HttpStatusCode.PaymentRequired, 
            "There is no enough credit to place this bet")
        {
        }
    }
}
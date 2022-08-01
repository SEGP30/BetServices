using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class AmountSurpassedException : BetServicesException
    {
        public AmountSurpassedException() : base(HttpStatusCode.PaymentRequired, 
            "Bet's amount to place has been surpassed")
        {
        }
    }
}
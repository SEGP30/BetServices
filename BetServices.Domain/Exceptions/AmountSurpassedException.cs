using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class AmountSurpassedException : BetServicesException
    {
        public AmountSurpassedException() : base(HttpStatusCode.BadRequest, 
            "Bet's amount to place has been surpassed")
        {
        }
    }
}
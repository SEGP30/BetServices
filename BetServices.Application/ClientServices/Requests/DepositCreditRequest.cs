namespace BetServices.Application.ClientServices.Requests
{
    public class DepositCreditRequest
    {
        public long ClientId { get; set; }
        public uint NewCredit { get; set; }
    }
}
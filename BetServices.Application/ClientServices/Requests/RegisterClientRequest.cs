using BetServices.Domain.Enums;

namespace BetServices.Application.ClientServices.Requests
{
    public class RegisterClientRequest
    {
        public long ClientId { get; set; }
        public string ClientNames { get; set; }
        public string ClientSurnames { get; set; }
        public Gender ClientGender { get; set; }
    }
}
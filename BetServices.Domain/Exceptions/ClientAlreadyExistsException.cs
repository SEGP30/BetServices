using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class ClientAlreadyExistsException : BetServicesException
    {
        public ClientAlreadyExistsException() : base(HttpStatusCode.Found, "Client already exits")
        {
        }
    }
}
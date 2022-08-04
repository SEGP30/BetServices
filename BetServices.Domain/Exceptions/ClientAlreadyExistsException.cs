using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class ClientAlreadyExistsException : BetServicesException
    {
        public ClientAlreadyExistsException() : base(HttpStatusCode.BadRequest, "Client already exits")
        {
        }
    }
}
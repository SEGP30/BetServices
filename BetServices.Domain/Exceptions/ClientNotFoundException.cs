using System;
using System.Net;

namespace BetServices.Domain.Exceptions
{
    public class ClientNotFoundException : BetServicesException
    {
        public ClientNotFoundException() : base(HttpStatusCode.NotFound, "No Client found with this Id")
        {
        }
    }
}
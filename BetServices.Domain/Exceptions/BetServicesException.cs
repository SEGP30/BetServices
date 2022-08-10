using System;
using System.Net;
using System.Threading.Tasks;
using BetServices.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace BetServices.Domain.Exceptions
{
    public abstract class BetServicesException : Exception
    {
        public readonly string CustomMessage;

        public readonly HttpStatusCode StatusCode;

        protected BetServicesException(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            CustomMessage = message;
        }

        public async Task SetHttpResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int) StatusCode;
            await httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = CustomMessage
            }.ToString());
        }
    }
}
using System;
using System.Net;
using BetServices.Domain.Exceptions;
using BetServices.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = contextFeature.Error;
                    switch (exception)
                    {
                        case BetServicesException transportManagerException:
                            await transportManagerException.SetHttpResponse(context);
                            break;
                        default:
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server error"
                            }.ToString());
                            break;
                    }
                });
            });
        }
    }
}
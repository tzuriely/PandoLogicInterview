using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PandoLogic.API.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)  
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var message = exception switch
            {
                FormatException => "DateTime format not valid",
                _ => "Internal Server Error from the custom middleware."
            };

            var ex = exception switch
            {
                FormatException => (int)HttpStatusCode.BadRequest,
                _ => context.Response.StatusCode
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex;

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = ex,
                Message = message
            }.ToString());
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Booking.Api.MyMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DateTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public DateTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.Headers.Add("my-middle-header", DateTime.Now.ToString());
            await Task.FromResult(_next(httpContext));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DateTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseDateTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DateTimeMiddleware>();
        }
    }
}

using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.Middleware
{
    /// <summary>
    /// Redirect error Pages to static pages
    /// </summary>
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Response.ContentLength.GetValueOrDefault(0) == 0)
                await _next(context);

            if (context.Request.Headers["X-Requested-With"] == "XMLHttpRequest") // If it is a AJAX request
                await _next(context);

            switch (context.Response.StatusCode)
            {
                case (int) HttpStatusCode.Unauthorized:
                    context.Response.Redirect("/Error/Unauthorized", true);
                    break;
                case (int) HttpStatusCode.Forbidden:
                    context.Response.Redirect("/Error/Forbidden", true);
                    break;
                case (int) HttpStatusCode.NotFound:
                    context.Response.Redirect("/Error/NotFound", true);
                    break;
                case (int) HttpStatusCode.InternalServerError:
                    context.Response.Redirect("/Error/InternalServerError", false);
                    break;
                case (int) HttpStatusCode.ServiceUnavailable:
                    context.Response.Redirect("/Error/ServiceUnavailable", false);
                    break;
            }

            await _next(context);
        }
    }
}
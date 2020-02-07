using Microsoft.AspNetCore.Builder;
using System.Net;

namespace Foodtopia.Middleware
{
    public static class ErrorHandler
    {
        public static void UseExceptionHandler(IApplicationBuilder app)
        {

            app.UseStatusCodePages(async context =>
            {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;

                switch (response.StatusCode)
                {
                    case (int)HttpStatusCode.Unauthorized:
                        response.Redirect("/Error/Unauthorized");
                        break;
                    case (int)HttpStatusCode.Forbidden:
                        response.Redirect("/Error/Forbidden");
                        break;
                    case (int)HttpStatusCode.NotFound:
                        response.Redirect("/Error/NotFound");
                        break;
                    case (int)HttpStatusCode.InternalServerError:
                        response.Redirect("/Error/InternalServerError");
                        break;
                    default:
                        break;
                }
            });

            //app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
    }
}
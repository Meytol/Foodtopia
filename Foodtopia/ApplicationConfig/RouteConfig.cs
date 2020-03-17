using System;
using Common.Model.Enum;
using Microsoft.AspNetCore.Builder;

namespace Foodtopia.ApplicationConfig
{
    public static class RouteConfig
    {
        public static void ConfigRoute(IApplicationBuilder app, RouteConfigOption routeConfig)
        {
            switch (routeConfig)
            {
                case RouteConfigOption.Basic:
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                    });
                    break;
                case RouteConfigOption.Full:
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

                        endpoints.MapControllerRoute(
                            name: "area",
                            pattern: "{area}/{controller}/{action=Index}/{id?}"
                        );

                    });
                    break;
            }
        }

    }
}
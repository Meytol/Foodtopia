using Foodtopia.ApplicationConfig;
using Foodtopia.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Foodtopia
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Cookie.ConfigureCookieSecurity(services);

            Ioc.ConfigureDependyInjection(services);

            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<DataTranslator>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseMiddleware<ErrorHandler>();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthorization();

            //Route.DefaultRouteConfigure(app);
            Route.AreaRouteConfigure(app);
        }
    }
}
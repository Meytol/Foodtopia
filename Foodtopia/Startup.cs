using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Authentication.Service;
using Authentication.Service.IService;
using Foodtopia.Middleware;
using Foodtopia.MiniServices;
using Foodtopia.MiniServices.IService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Repository;
using Service.Repository.IRepository;

namespace Foodtopia
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            CookieHandler.ConfigureCookieSecurity(services);

            IocHandler.ConfigureDependyInjection(services);

            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                ErrorHandler.UseExceptionHandler(app);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthorization();

           //RouteHandler.DefaultRoute(app);
           RouteHandler.AreaRoute(app);
        }
    }
}

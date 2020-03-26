using Common.Model.Enum;
using DataAccess.Context;
using Foodtopia.ApplicationConfig;
using Foodtopia.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

namespace Foodtopia
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration config)
        {
            _configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Cookie.ConfigureCookieSecurity(services);

            Ioc.ConfigureDependyInjection(services);

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
                //.SetCompatibilityVersion(CompatibilityVersion.Latest);NA

            services.AddDbContext<DatabaseContext>(options =>
                //options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
                options.UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

            services.AddSession();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<DataTranslator>();

            app.UseSession();

            app.UseMiddleware<CheckAuthenticationSession>();

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

            app.UseRouting();

            app.UseAuthorization();

            RouteConfig.ConfigRoute(app, RouteConfigOption.Full);

            app.UseCookiePolicy();
        }
    }
}
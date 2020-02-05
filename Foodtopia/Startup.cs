using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Repository;
using Service.Repository.IRepository;

namespace Foodtopia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region IOC

            #region Models

            services.AddTransient<IApplicationActionService, ApplicationActionService>();
            services.AddTransient<ICartRestaurantFoodService, CartRestaurantFoodService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IFoodCategoryService, FoodCategoryService>();
            services.AddTransient<IFoodService, FoodService>();
            services.AddTransient<IFoodTypeService, FoodTypeService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IRestaurantFoodCommentService, RestaurantFoodCommentService>();
            services.AddTransient<IRestaurantFoodDiscountService, RestaurantFoodDiscountService>();
            services.AddTransient<IRestaurantFoodImageService, RestaurantFoodImageService>();
            services.AddTransient<IRestaurantFoodRatingService, RestaurantFoodRatingService>();
            services.AddTransient<IRestaurantFoodService, RestaurantFoodService>();
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddTransient<IRestaurantTypeService, RestaurantTypeService>();
            services.AddTransient<IRestaurantUserService, RestaurantUserService>();
            services.AddTransient<IRoleActionService, RoleActionService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IUserDiscountCodeService, UserDiscountCodeService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationCodeService, AuthenticationCodeService>();

            #endregion

            #region Mini Services

            services.AddTransient<IUserCookieService, UserCookieService>();
            services.AddTransient<IUserSessionService, UserSessionService>();

            #endregion

            #region Authentication

            services.AddTransient<IAuthorizeService, AuthorizeService>();
            services.AddTransient<ISecurityService, SecurityService>();

            #endregion

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}

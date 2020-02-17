using Authentication.Service;
using Authentication.Service.IService;
using Foodtopia.MiniServices;
using Foodtopia.MiniServices.IService;
using Microsoft.Extensions.DependencyInjection;
using Service.Repository;
using Service.Repository.IRepository;

namespace Foodtopia.ApplicationConfig
{
    public static class Ioc
    {
        public static void ConfigureDependyInjection(IServiceCollection services)
        {
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
            services.AddTransient<IEmailSerivce, EmailService>();
            services.AddTransient<IEmailUserService, EmailUserService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<ISmsUserService, SmsUserService>();

            #endregion

            #region Mini Services

            services.AddTransient<IUserCookieService, UserCookieService>();
            services.AddTransient<IUserSessionService, UserSessionService>();

            #endregion

            #region Authentication

            services.AddTransient<IAuthorizeService, AuthorizeService>();
            services.AddSingleton<ISecurityService, SecurityService>();

            #endregion
        }
    }
}
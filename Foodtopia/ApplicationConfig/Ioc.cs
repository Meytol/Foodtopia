using Authentication.Interface;
using Authentication.Service;
using Common.Cryptography.Interface;
using Common.Cryptography.Service;
using Foodtopia.MiniServices.Intereface;
using Foodtopia.MiniServices.Service;
using Microsoft.Extensions.DependencyInjection;
using RepositoryService.Interface;
using RepositoryService.Service;
using ValidationService.Interface;
using ValidationService.Service;

namespace Foodtopia.ApplicationConfig
{
    public static class Ioc
    {
        public static void ConfigureDependyInjection(IServiceCollection services)
        {
            #region Repository

            services.AddTransient<IApplicationActionRepository, ApplicationActionRepository>();
            services.AddTransient<ICartRestaurantFoodRepository, CartRestaurantFoodRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IFoodCategoryRepository, FoodCategoryRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IFoodTypeRepository, FoodTypeRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IRestaurantFoodCommentRepository, RestaurantFoodCommentRepository>();
            services.AddTransient<IRestaurantFoodDiscountRepository, RestaurantFoodDiscountRepository>();
            services.AddTransient<IRestaurantFoodImageRepository, RestaurantFoodImageRepository>();
            services.AddTransient<IRestaurantFoodRatingRepository, RestaurantFoodRatingRepository>();
            services.AddTransient<IRestaurantFoodRepository, RestaurantFoodRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IRestaurantTypeRepository, RestaurantTypeRepository>();
            services.AddTransient<IRestaurantUserRepository, RestaurantUserRepository>();
            services.AddTransient<IRoleActionRepository, RoleActionRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<IUserAddressRepository, UserAddressRepository>();
            services.AddTransient<IUserDiscountCodeRepository, UserDiscountCodeRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthenticationCodeRepository, AuthenticationCodeRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IEmailUserRepository, EmailUserRepository>();
            services.AddTransient<ISmsRepository, SmsRepository>();
            services.AddTransient<ISmsUserRepository, SmsUserRepository>();

            #endregion

            #region Validation

            services.AddTransient<IApplicationActionValidation, ApplicationActionValidation>();
            services.AddTransient<ICartRestaurantFoodValidation, CartRestaurantFoodValidation>();
            services.AddTransient<ICartValidation, CartValidation>();
            services.AddTransient<ICityValidation, CityValidation>();
            services.AddTransient<IFoodCategoryValidation, FoodCategoryValidation>();
            services.AddTransient<IFoodValidation, FoodValidation>();
            services.AddTransient<IFoodTypeValidation, FoodTypeValidation>();
            services.AddTransient<IOrderDetailValidation, OrderDetailValidation>();
            services.AddTransient<IOrderValidation, OrderValidation>();
            services.AddTransient<IProvinceValidation, ProvinceValidation>();
            services.AddTransient<IRestaurantFoodCommentValidation, RestaurantFoodCommentValidation>();
            services.AddTransient<IRestaurantFoodDiscountValidation, RestaurantFoodDiscountValidation>();
            services.AddTransient<IRestaurantFoodImageValidation, RestaurantFoodImageValidation>();
            services.AddTransient<IRestaurantFoodRatingValidation, RestaurantFoodRatingValidation>();
            services.AddTransient<IRestaurantFoodValidation, RestaurantFoodValidation>();
            services.AddTransient<IRestaurantValidation, RestaurantValidation>();
            services.AddTransient<IRestaurantTypeValidation, RestaurantTypeValidation>();
            services.AddTransient<IRestaurantUserValidation, RestaurantUserValidation>();
            services.AddTransient<IRoleActionValidation, RoleActionValidation>();
            services.AddTransient<IRoleValidation, RoleValidation>();
            services.AddTransient<ISettingValidation, SettingValidation>();
            services.AddTransient<IUserAddressValidation, UserAddressValidation>();
            services.AddTransient<IUserDiscountCodeValidation, UserDiscountCodeValidation>();
            services.AddTransient<IUserRoleValidation, UserRoleValidation>();
            services.AddTransient<IUserValidation, UserValidation>();
            services.AddTransient<IAuthenticationCodeValidation, AuthenticationCodeValidation>();
            services.AddTransient<IEmailValidation, EmailValidation>();
            services.AddTransient<IEmailUserValidation, EmailUserValidation>();
            services.AddTransient<ISmsValidation, SmsValidation>();
            services.AddTransient<ISmsUserValidation, SmsUserValidation>();

            #endregion

            #region Mini Services

            services.AddTransient<IUserCookieService, UserCookieService>();
            services.AddTransient<IUserSessionService, UserSessionService>();

            #endregion

            #region Authentication

            services.AddTransient<IAuthorizeService, AuthorizeService>();
            services.AddSingleton<ICryptographyService, CryptographyService>();

            #endregion
        }
    }
}
using System;
using Authentication.ViewModel.Cookie;
using Common.Cryptography.Interface;
using Foodtopia.MiniServices.Intereface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Foodtopia.MiniServices.Service
{
    public class AuthenticationCookieService : IAuthenticationCookieService
    {
        private readonly IConfiguration _configuration;
        private readonly ICryptographyService _cryptographyService;
        private readonly string _cookieName;
        private readonly string _encryptionKey;
        private readonly string _oldEncryptionKey;

        public AuthenticationCookieService(IConfiguration configuration, ICryptographyService cryptographyService)
        {
            _configuration = configuration;
            _cryptographyService = cryptographyService;

            _encryptionKey = _configuration.GetValue<string>("AppSetting:AuthCookieEncryptionKey");
            _oldEncryptionKey = _configuration.GetValue<string>("AppSetting:OldAuthCookieEncryptionKey");
            _cookieName = _configuration.GetValue<string>("AppSetting:AuthCookieName");
        }

        public AuthenticationCookieViewModel Get(HttpContext context)
        {
            var encryptedAuthCookie = context.Request.Cookies[_cookieName];

            if (string.IsNullOrWhiteSpace(encryptedAuthCookie))
            {
                return null;
            }

            var authenticationCookie =
                _cryptographyService.Decrypt<AuthenticationCookieViewModel>(encryptedAuthCookie, _encryptionKey) ??
                _cryptographyService.Decrypt<AuthenticationCookieViewModel>(encryptedAuthCookie, _oldEncryptionKey);

            return authenticationCookie;

        }

        public void Set(HttpContext context, AuthenticationCookieViewModel cookieViewModel, CookieOptions options)
        {
            var cipherAuthenticationCookie =
                _cryptographyService.Encrypt(cookieViewModel, _encryptionKey);


            if (!options.Expires.HasValue)
            {
                var timeSpan = cookieViewModel.RememberMe ? TimeSpan.FromDays(30) : TimeSpan.FromHours(1);
                options.Expires = DateTimeOffset.Now.Add(timeSpan);
            }

            if (!options.MaxAge.HasValue)
            {
                var maxAge = cookieViewModel.RememberMe ? TimeSpan.FromDays(180) : TimeSpan.FromDays(1);
                options.MaxAge = maxAge;
            }

            context.Response.Cookies.Append(cipherAuthenticationCookie, _cookieName, options);
        }

        public void Update(HttpContext context, AuthenticationCookieViewModel cookie, CookieOptions options)
        {
            Remove(context);

            Set(context, cookie, options);
        }

        public void AddExpireTime(HttpContext context)
        {
            var cookie = Get(context);

            var timeSpan = cookie.RememberMe ? TimeSpan.FromDays(30) : TimeSpan.FromHours(1);

            var maxAge = cookie.MaxAgeDateTime.Subtract(DateTime.Now);

            var optios = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.Add(timeSpan),
                MaxAge = maxAge
            };

            Update(context, cookie, optios);
        }

        public void Expire(HttpContext context)
        {
            var cookie = Get(context);

            var optios = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.Add(TimeSpan.FromDays(-1)),
                MaxAge = TimeSpan.FromDays(-1)
            };

            Update(context, cookie, optios);
        }

        public void Remove(HttpContext context)
        {
            context.Response.Cookies.Delete(_cookieName);
        }
    }
}
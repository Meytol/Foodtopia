using Authentication.ViewModel.Cookie;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.MiniServices.Intereface
{
    public interface IAuthenticationCookieService
    {
        AuthenticationCookieViewModel Get(HttpContext context);
        void Set(HttpContext context, AuthenticationCookieViewModel cookieViewModel, CookieOptions options);
        void Update(HttpContext context, AuthenticationCookieViewModel cookieViewModel, CookieOptions options);
        void AddExpireTime(HttpContext context);
        void Expire(HttpContext context);
        void Remove(HttpContext context);
    }
}
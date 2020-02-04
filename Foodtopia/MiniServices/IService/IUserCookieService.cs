using Authentication.ViewModel.Cookie;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.MiniServices.IService
{
    public interface IUserCookieService
    {
        UserCookieViewModel Get(HttpContext context);
        void Set(HttpContext context);
        void Update(HttpContext context);
        void AddExpireTime(HttpContext context);
        void Dispose(HttpContext context);
    }
}
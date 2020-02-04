using Authentication.ViewModel.Cookie;
using Foodtopia.MiniServices.IService;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.MiniServices
{
    public class UserCookieService : IUserCookieService
    {

        public UserCookieViewModel Get(HttpContext context)
        {
            var encryptedUserCookie = context.Request.Cookies[""];

            throw new System.NotImplementedException();
        }

        public void Set(HttpContext context)
        {
            throw new System.NotImplementedException();
        }

        public void Update(HttpContext context)
        {
            throw new System.NotImplementedException();
        }

        public void AddExpireTime(HttpContext context)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose(HttpContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
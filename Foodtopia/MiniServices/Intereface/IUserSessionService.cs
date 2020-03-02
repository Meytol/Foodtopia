using Microsoft.AspNetCore.Http;

namespace Foodtopia.MiniServices.Intereface
{
    public interface IUserSessionService
    {

        void Get(HttpContext context);
        void Set(HttpContext context);
        void Update(HttpContext context);
        void Dispose(HttpContext context);
    }
}
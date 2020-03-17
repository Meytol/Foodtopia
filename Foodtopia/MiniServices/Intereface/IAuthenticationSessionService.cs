using Authentication.ViewModel.Session;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.MiniServices.Intereface
{
    public interface IAuthenticationSessionService
    {

        AuthenticationSessionViewModel Get(HttpContext context);
        void Set(HttpContext context, AuthenticationSessionViewModel sessionViewModel);
        void Update(HttpContext context, AuthenticationSessionViewModel sessionViewModel);
        void Remove(HttpContext context);
    }
}
using Authentication.ViewModel.Cookie;
using Authentication.ViewModel.Session;
using DataAccess.Model;

namespace Authentication.Service.IService
{
    public interface IAuthorizeService
    {
        bool CheckUserPermision(string areaTitle, string controllerTitle, string actionTitle, int userId);
        bool CheckUserCookie(UserCookieViewModel userCookie);
        bool CheckUserSession(UserSessionViewModel userSession);
        User GetUser(string userName, string password);
    }
}
using Authentication.Service.IService;
using Authentication.ViewModel.Cookie;
using Authentication.ViewModel.Session;
using DataAccess.Model;

namespace Authentication.Service
{
    public class AuthorizeService : IAuthorizeService
    {
        public bool CheckUserPermision(string areaTitle, string controllerTitle, string actionTitle, int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckUserCookie(UserCookieViewModel userCookie)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckUserSession(UserSessionViewModel userSession)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
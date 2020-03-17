using System;
using Authentication.ViewModel.Cookie;
using Authentication.ViewModel.Session;
using DataAccess.Model;
using RepositoryService.Models.User;

namespace Authentication.Interface
{
    public interface IAuthorizeService
    {
        bool CheckUserPermision(string areaTitle, string controllerTitle, string actionTitle, int userId);
        bool CheckUserCookie(AuthenticationCookieViewModel authenticationCookie);
        bool CheckUserSession(AuthenticationSessionViewModel authenticationSession);
        SignInViewModel GetUser(string phoneNumber, string password);
    }
}
using System;
using System.Net;
using Authentication.Common;
using Authentication.Interface;
using Foodtopia.MiniServices.Intereface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Foodtopia.Common.Attribute
{
    [AttributeUsage(AttributeTargets.All)]
    public class Grant : ActionFilterAttribute
    {
        private readonly AuthorizeLevel _grantType;
        private HttpContext _httpContext;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserCookieService _userCookieService;
        private readonly IUserSessionService _userSessionService;
        private readonly IAuthorizeService _authorizeService;

        public Grant()
        {
            _grantType = AuthorizeLevel.NeedAuthorize;
        }

        public Grant(AuthorizeLevel grantType)
        {
            _grantType = grantType;
        }

        public Grant(IHttpContextAccessor httpContextAccessor, IUserCookieService userCookieService, IUserSessionService userSessionService, IAuthorizeService authorizeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userCookieService = userCookieService;
            _userSessionService= userSessionService;
            _authorizeService = authorizeService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_grantType == AuthorizeLevel.AllowAnanymos)
                return;

            _httpContext = _httpContextAccessor.HttpContext;
            var userId = 0;

            try
            {
                var path = _httpContextAccessor.HttpContext.Request.Path.Value;

                var userSession = _userCookieService.Get(_httpContext);
                var userCookie = _userCookieService.Get(_httpContext);

                if (userSession == null)
                {
                    if (userCookie != null && _authorizeService.CheckUserCookie(userCookie))
                    {
                        var userName = userCookie.UserName;
                        var password = userCookie.UserPassword;

                        var user = _authorizeService.GetUser(userName: userName, password: password);

                        if (user != null)
                        {
                            _userSessionService.Update(_httpContext);
                            userId = user.Id;
                        }
                        else
                        {
                            throw new UnauthorizedAccessException();
                            //filterContext.Result = new RedirectResult("/Account/Logout");
                            //return;
                        }
                    }
                    else // User Cookie is null or it isn't valid
                    {
                        filterContext.Result = new RedirectResult("/Account/LogIn?returnUrl=" + path);
                        return;
                    }
                }
                else if (userCookie == null) // both of User Session is not null but User Cookie is null 
                {
                    filterContext.Result = new RedirectResult("/Account/Login?returnUrl=" + path);
                    return;
                }
                else // User Session and User Cookie isn't null
                {
                    userId = userCookie.UserId;
                }

                if (_grantType == AuthorizeLevel.LogedIn)
                    return;

                var areaTitle = filterContext.RouteData.DataTokens["Area"].ToString();
                var controllerTitle = filterContext.RouteData.Values["Controller"].ToString();
                var actionTitle = filterContext.RouteData.Values["Action"].ToString();

                var hasAccess = _authorizeService.CheckUserPermision(areaTitle: areaTitle,
                    controllerTitle: controllerTitle, actionTitle: actionTitle, userId: userId);

                if (!hasAccess)
                    throw new UnauthorizedAccessException();
                
                _userCookieService.AddExpireTime(_httpContext);

            }
            catch (UnauthorizedAccessException)
            {
                if (IsAjaxRequest())
                {
                    filterContext.Result = userId == 0 
                        ? new JsonResult(new { HttpStatusCode.Unauthorized }) 
                        : new JsonResult(new { HttpStatusCode.Forbidden });
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = userId == 0
                        ? (int) System.Net.HttpStatusCode.Unauthorized
                        : (int) System.Net.HttpStatusCode.Forbidden;
                }
            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
        }

        private bool IsAjaxRequest()
        {
            if (_httpContext?.Request == null)
                throw new ArgumentNullException("Http Requset");

            if (_httpContext.Request != null)
                return _httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            return false;
        }
    }
}
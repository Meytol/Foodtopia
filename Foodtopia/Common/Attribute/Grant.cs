﻿using Authentication.Service.IService;
using Authentication.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using Foodtopia.MiniServices.IService;
using Microsoft.AspNetCore.Mvc;
using Service.Repository.IRepository;
using IUserCookieService = Foodtopia.MiniServices.IService.IUserCookieService;

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
        private readonly IUserService _userService;


        public Grant()
        {
            _grantType = AuthorizeLevel.NeedAuthorize;
        }

        public Grant(AuthorizeLevel grantType)
        {
            _grantType = grantType;

            if (grantType != AuthorizeLevel.AuthorizeWithRole)
                return;

            if (string.IsNullOrWhiteSpace(roleName))
            {
                _grantType = AuthorizeLevel.NeedAuthorize;
            }
            else
            {
                _grantType = grantType;
            }

        }

        public Grant(IHttpContextAccessor httpContextAccessor, IUserCookieService userCookieService, IUserService userService, IUserSessionService userSessionService, IAuthorizeService authorizeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userCookieService = userCookieService;
            _userSessionService= userSessionService;
            _userService = userService;
            _authorizeService = authorizeService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_grantType == AuthorizeLevel.AllowAnanymos)
                return;

            _httpContext = _httpContextAccessor.HttpContext;

            try
            {
                var userId = 0;
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
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("/Account/Logout");
                            return;
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

                var hasAccess = _authorizeService.CheckUserPermision(areaTitle: areaTitle, controllerTitle: controllerTitle, actionTitle: actionTitle, userId: userId);

                if (hasAccess)
                {
                    _userCookieService.AddExpireTime(_httpContext);
                    return;
                }

                if (IsAjaxRequest)
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                    return;
                }

                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                filterContext.Result = new RedirectResult("/Error/ForbidenAccess");
            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                filterContext.Result = new RedirectResult("/Account/Logout");
            }
        }
        
        private bool IsAjaxRequest()
        {
            if (_httpContext == null || _httpContext.Requset == null)
                throw new ArgumentNullException("Http Requset");

            if (_httpContext.Request["X-Requested-With"] == "XMLHttpRequest")
                return true;

            if (_httpContext.Request != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";

            return false;
        }
    }
}
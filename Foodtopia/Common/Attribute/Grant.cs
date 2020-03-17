using System;
using System.Net;
using System.Text;
using Authentication.Common;
using Authentication.Interface;
using Authentication.ViewModel.Session;
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
        private readonly GrantPriority _grantPriority;

        private readonly HttpContext _httpContext;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationCookieService _authCookieService;
        private readonly IAuthenticationSessionService _authSessionService;
        private readonly IAuthorizeService _authorizeService;

        private readonly string _isAuthenticationChecked;

        public Grant(IHttpContextAccessor httpContextAccessor, IAuthenticationCookieService authCookieService, IAuthenticationSessionService authSessionService, IAuthorizeService authorizeService,
            AuthorizeLevel grantType = AuthorizeLevel.NeedAuthorize, GrantPriority grantPriority = GrantPriority.Default)
        {
            _httpContextAccessor = httpContextAccessor;
            _authCookieService = authCookieService;
            _authSessionService= authSessionService;
            _authorizeService = authorizeService;

            _grantType = grantType;
            _httpContext = _httpContextAccessor.HttpContext;
            _isAuthenticationChecked = "IsAuthenticationChecked";

            _grantPriority = grantPriority;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.TryGetValue(_isAuthenticationChecked, out var boolBytes))
            {
                var boolString = Encoding.UTF8.GetString(boolBytes);

                if (bool.Parse(boolString))
                {
                    return;
                }
            }

            var userId = 0;

            try
            {

                if (_grantType == AuthorizeLevel.AllowAnanymos)
                    return;



                var path = _httpContextAccessor.HttpContext.Request.Path.Value;

                var authSession = _authSessionService.Get(_httpContext);
                var authCookie = _authCookieService.Get(_httpContext);

                if (authSession == null || !_authorizeService.CheckUserSession(authSession))
                {
                    if (authCookie == null || !_authorizeService.CheckUserCookie(authCookie))
                    {
                        filterContext.Result = new RedirectResult("/Account/LogIn?returnUrl=" + path);
                        return;
                    }
                    else
                    {
                        var phoneNumber = authCookie.PhoneNumber;
                        var password = authCookie.Password;

                        var user = _authorizeService.GetUser(phoneNumber: phoneNumber, password);

                        if (user != null)
                        {
                            var session = new AuthenticationSessionViewModel()
                            {
                                UserId = user.Id,
                                UserFullName = user.Fullname
                            };

                            _authSessionService.Update(_httpContext, session);
                            authSession = _authSessionService.Get(_httpContext);
                            userId = user.Id;
                        }
                        else
                        {
                            throw new UnauthorizedAccessException();
                            //filterContext.Result = new RedirectResult("/Account/Logout");
                            //return;
                        }
                    }
                }
                else if (authCookie == null) // both of User Session is NOT null but User Cookie is null 
                {
                    _authSessionService.Remove(_httpContext);

                    filterContext.Result = new RedirectToActionResult("SignIn", "User", new {area = "Account"});
                    return;
                }
                else // User Session and User Cookie isn't null
                {
                    userId = authCookie.UserId;
                }

                if (_grantType == AuthorizeLevel.LogedIn)
                    return;

                var areaTitle = string.Empty;

                try
                {
                    areaTitle = filterContext.RouteData.DataTokens["Full"].ToString();
                }
                catch (Exception e)
                {
                    // Do nothing
                }

                var controllerTitle = filterContext.RouteData.Values["Controller"].ToString();
                var actionTitle = filterContext.RouteData.Values["Action"].ToString();



                var hasAccess = _authorizeService.CheckUserPermision(areaTitle: areaTitle,
                    controllerTitle: controllerTitle, actionTitle: actionTitle, userId: userId);

                if (!hasAccess)
                    throw new UnauthorizedAccessException();

                _authCookieService.AddExpireTime(_httpContext);

            }
            catch (UnauthorizedAccessException)
            {
                if (IsAjaxRequest())
                {
                    filterContext.Result = userId == 0
                        ? new JsonResult(new {HttpStatusCode.Unauthorized})
                        : new JsonResult(new {HttpStatusCode.Forbidden});
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
                if (IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult(new {HttpStatusCode.InternalServerError});
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.InternalServerError;
                }
            }
            finally
            {
                if (_grantPriority == GrantPriority.Override)
                {
                    if (filterContext.HttpContext.Session.TryGetValue(_isAuthenticationChecked, out var buffer))
                    {

                        var converted = bool.Parse(Encoding.UTF8.GetString(buffer));

                        if (converted)
                        {

                        }
                        else
                        {
                            var trueString = bool.TrueString;
                            var bytes = Encoding.UTF8.GetBytes(trueString);

                            filterContext.HttpContext.Session.Set(_isAuthenticationChecked, bytes);
                        }
                    }
                    else
                    {
                        var trueString = bool.TrueString;
                        var bytes = Encoding.UTF8.GetBytes(trueString);

                        filterContext.HttpContext.Session.Set(_isAuthenticationChecked, bytes);
                    }
                }
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
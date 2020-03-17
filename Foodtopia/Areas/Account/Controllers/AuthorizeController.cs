using System;
using System.Threading.Tasks;
using Authentication.Common;
using Authentication.ViewModel.Cookie;
using Authentication.ViewModel.Session;
using Common.Model;
using Common.Model.Enum;
using Foodtopia.Common.Attribute;
using Foodtopia.Common.Controllers;
using Foodtopia.MiniServices.Intereface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryService.Interface;
using RepositoryService.Models.User;

namespace Foodtopia.Areas.Account.Controllers
{
    public class AuthorizeController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationCookieService _authenticationCookieService;
        private readonly IAuthenticationSessionService _authentcationSessionService;

        public AuthorizeController(IUserRepository userRepository, IAuthenticationCookieService authenticationCookieService, IAuthenticationSessionService authentcationSessionService)
        {
            _userRepository = userRepository;
            _authenticationCookieService = authenticationCookieService;
            _authentcationSessionService = authentcationSessionService;
        }


        [HttpGet]
        [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.AllowAnanymos, GrantPriority.Override })]
        public IActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.AllowAnanymos, GrantPriority.Override })]
        public async Task<ApiResult<SignUpViewModel>> SignUp(SignUpViewModel model)
        {
            return await _userRepository.SignUp(model);
        }

        [HttpGet]
        [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.AllowAnanymos, GrantPriority.Override })]
        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.AllowAnanymos, GrantPriority.Override })]
        public async Task<ApiResult<SignInViewModel>> SignIn(SignInViewModel model)
        {
            var signInResult = await _userRepository.SignIn(model);

            var result = new ApiResult<SignInViewModel>();

            if (!signInResult.Success && signInResult.MessageType != MessageType.Success)
            {
                result.Success = false;
                result.Data = null;
                result.Info = signInResult.Info;
                result.Message = signInResult.Message;
                result.MessageType = signInResult.MessageType;

                return result;
            }

            var timeSpan = model.RememberMe ? TimeSpan.FromDays(30) : TimeSpan.FromHours(1);
            var maxAge = model.RememberMe ? TimeSpan.FromDays(180) : TimeSpan.FromDays(1);

            var cookie = new AuthenticationCookieViewModel()
            {
                PhoneNumber = signInResult.Data.PhoneNumber,
                UserId = signInResult.Data.Id,
                Password = signInResult.Data.Password,
                RememberMe = model.RememberMe,
                MaxAgeDateTime = DateTime.Now.Add(maxAge)
            };

            var cookieOptions = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.Add(timeSpan),
                MaxAge = maxAge,
            };

            _authenticationCookieService.Set(HttpContext, cookie, cookieOptions);

            var session = new AuthenticationSessionViewModel()
            {
                UserId = signInResult.Data.Id,
                UserFullName = signInResult.Data.Fullname
            };

            _authentcationSessionService.Set(HttpContext, session);

            result.Success = true;
            result.Data = signInResult.Data;
            result.Info = signInResult.Info;
            result.Message = signInResult.Message;
            result.MessageType = signInResult.MessageType;

            return result;

        }

        [HttpGet]
        [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.LogedIn })]
        public IActionResult SignOut()
        {
            _authenticationCookieService.Expire(HttpContext);
            _authentcationSessionService.Remove(HttpContext);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Areas.Account.Controllers
{
    public class AuthorizeController : BaseController
    {
        public IActionResult LogIn(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(object loginViewModel)
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(object forgetPasswordViewModel)
        {
            return View();
        }
    }
}
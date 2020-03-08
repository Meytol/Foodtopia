using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using RepositoryService.Interface;

namespace Foodtopia.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public PartialViewResult CookiePrivacy()
        {
            return PartialView();
        }
    }
}

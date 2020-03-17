using Authentication.Common;
using Foodtopia.Common.Attribute;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Controllers
{
    
    [TypeFilter(typeof(Grant), Arguments = new object[] {AuthorizeLevel.AllowAnanymos})]
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

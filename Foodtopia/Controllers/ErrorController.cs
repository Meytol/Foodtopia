using Authentication.Common;
using Foodtopia.Common.Attribute;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Controllers
{
    [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.AllowAnanymos, GrantPriority.Override })]
    public class ErrorController : BaseController
    {
        public IActionResult Unauthorized() //401
        {
            return View();
        }

        public IActionResult Forbidden() //403
        {
            return View();
        }

        public IActionResult NotFound() //404
        {
            return View();
        }

        public IActionResult InternalServerError() //500
        {
            return View();
        }
    }
}
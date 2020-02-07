using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Common;
using Foodtopia.Common.Attribute;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Controllers
{
    [Grant(AuthorizeLevel.AllowAnanymos)]
    public class ErrorController : BaseController
    {
        public IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult InternalServerError()
        {
            return View();
        }
    }
}
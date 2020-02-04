using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Areas.Account.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(object userDetail)
        {
            return View();
        }

        public IActionResult Deactivate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deactivate(object userDetail)
        {
            return View();
        }
    }
}
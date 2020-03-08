using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Common;
using Common.Model;
using Foodtopia.Common.Attribute;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Controllers
{
    [Grant(AuthorizeLevel.AllowAnanymos)]
    public class SearchController : BaseController
    {
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByHeader = "*")]
        [HttpGet]
        public IActionResult Get(string q)
        {
            if (q.Trim().Length < 3)
            {
                return null;
            }

            return null;
        }
    }
}
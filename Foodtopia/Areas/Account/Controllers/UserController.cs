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
    public class UserController : BaseController
    {

        [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.LogedIn })]
        public IActionResult Index()
        {
            return View();
        }

       

    }
}
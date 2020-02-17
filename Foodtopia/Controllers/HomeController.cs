using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Service.Repository.IRepository;

namespace Foodtopia.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApplicationActionService _applicationActionService;

        public HomeController(IApplicationActionService applicationActionService)
        {
            _applicationActionService = applicationActionService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Common.Controllers
{
    public class ViewComponentController : Controller
    {
        [Route("ViewComponent/InvokeAsync")]
        [HttpGet]
        public ViewComponentResult InvokeAsync(string vcname, dynamic arg)
        {
            if (arg == null)
                return ViewComponent(vcname);
            else
                return ViewComponent(vcname, new {arg});
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.ViewComponents.Base
{
    [ViewComponent]
    public class Counter : ViewComponent
    {

        public Counter()
        {
        }

        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)] // 1 day
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

        //[ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)] // 1 day
        //public IViewComponentResult Invoke()
        //{
        //    return View(_viewName);
        //}
    }
}
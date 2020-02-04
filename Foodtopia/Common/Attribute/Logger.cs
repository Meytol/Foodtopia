using Microsoft.AspNetCore.Mvc.Filters;

namespace Foodtopia.Common.Attribute
{
    public class Logger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}
using Authentication.Common;
using Foodtopia.Common.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Common.Controllers
{
    [Logger]
    [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.NeedAuthorize, GrantPriority.Default })]
    public class BaseController : Controller
    {

    }
}
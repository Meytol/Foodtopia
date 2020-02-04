using Foodtopia.Common.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Foodtopia.Common.Controllers
{
    [Logger]
    [Grant]
    public class BaseController : Controller
    {

    }
}
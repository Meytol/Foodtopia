using Authentication.Common;
using Foodtopia.Common.Attribute;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using RepositoryService.Interface;

namespace Foodtopia.Controllers
{
    [TypeFilter(typeof(Grant), Arguments = new object[] { AuthorizeLevel.AllowAnanymos, GrantPriority.Override })]
    public class RestaurantsController : BaseController
    {
        private readonly IFoodRepository _food;
        private readonly IRestaurantFoodRepository _restaurantFood;
        private readonly IRestaurantRepository _restaurant;
        private readonly IFoodCategoryRepository _foodCategory;
        private readonly IFoodTypeRepository _foodType;

        public RestaurantsController(IFoodTypeRepository foodType, IFoodCategoryRepository foodCategory, IRestaurantRepository restaurant, IRestaurantFoodRepository restaurantFood, IFoodRepository food)
        {
            _foodType = foodType;
            _foodCategory = foodCategory;
            _restaurant = restaurant;
            _restaurantFood = restaurantFood;
            _food = food;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu(int restaurantId)
        {
            return View();
        }
    
        public IActionResult Details(int restaurantId)
        {
            return View();
        }

    }
}
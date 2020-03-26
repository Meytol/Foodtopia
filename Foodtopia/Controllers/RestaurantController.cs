using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Foodtopia.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryService.Interface;

namespace Foodtopia.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IFoodRepository _food;
        private readonly IRestaurantFoodRepository _restaurantFood;
        private readonly IRestaurantRepository _restaurant;
        private readonly IFoodCategoryRepository _foodCategory;
        private readonly IFoodTypeRepository _foodType;

        public RestaurantController(IFoodTypeRepository foodType, IFoodCategoryRepository foodCategory, IRestaurantRepository restaurant, IRestaurantFoodRepository restaurantFood, IFoodRepository food)
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
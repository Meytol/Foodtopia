﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryService.Interface;

namespace Foodtopia.ViewComponents.Restaurant
{
    [ViewComponent]
    public class GetMenu : ViewComponent
    {
        private readonly IRestaurantFoodRepository _restaurantFood;
        private readonly string _viewName;

        public GetMenu(IRestaurantFoodRepository restaurantFood)
        {
            _restaurantFood = restaurantFood;
            _viewName = "_Menu";
        }

        public async Task<IViewComponentResult> InvokeAsync(int restaurantId)
        {
            var result = new ApiResult<JsonResult>();

            if (restaurantId == 0)
            {
                throw new Exception();
            }

            try
            {
                var resaurantFoods =  await 
                        _restaurantFood.GetAllIncluding(rf => rf.RestaurantId == restaurantId).Data
                            .Include(rf => rf.Food)
                            .ThenInclude(f => f.FoodTypes)
                            .ThenInclude(ft => ft.FoodCategory)
                            .ToListAsync();

                if (!resaurantFoods.Any())
                {
                    return null;
                }

                return View(_viewName, resaurantFoods);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Info = "";
                result.Exception = e;
                result.Message = "رکوردی پیدا نشد";

                return View(_viewName, result);
            }

        }

        public IViewComponentResult Invoke(int restaurantId)
        {
            var result = new ApiResult<JsonResult>();

            if (restaurantId == 0)
            {
                throw new Exception();
            }

            try
            {
                var resaurantFoods =
                    _restaurantFood.GetAllIncluding(rf => rf.RestaurantId == restaurantId).Data
                        .Include(rf => rf.Food)
                        .ThenInclude(f => f.FoodTypes)
                        .ThenInclude(ft => ft.FoodCategory)
                        .ToList();

                if (!resaurantFoods.Any())
                {
                    return null;
                }

                return View(_viewName, resaurantFoods);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Info = "";
                result.Exception = e;
                result.Message = "رکوردی پیدا نشد";

                return View(_viewName, result);
            }

        }
    }
}
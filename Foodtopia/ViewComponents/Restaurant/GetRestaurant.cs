using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryService.Interface;

namespace Foodtopia.ViewComponents.Restaurant
{
    [ViewComponent]
    public class GetRestaurant : ViewComponent
    {
        private readonly IRestaurantRepository _restaurant;
        private readonly string _viewName;

        public GetRestaurant(IRestaurantRepository restaurant)
        {
            _restaurant = restaurant;
            _viewName = "_RestaurantInfo";
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
                var restaurant = await
                        _restaurant.GetAllIncluding(r => r.Id == restaurantId).Data
                            .Include(r => r.City)
                            .ThenInclude(c => c.Province)
                            .FirstOrDefaultAsync();

                if (restaurant == null)
                {
                    return null;
                }

                return View(_viewName, restaurant);
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
                var restaurant = 
                    _restaurant.GetAllIncluding(r => r.Id == restaurantId).Data
                        .Include(r => r.City)
                        .ThenInclude(c => c.Province)
                        .FirstOrDefault();

                if (restaurant == null)
                {
                    return null;
                }

                return View(_viewName, restaurant);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using DataAccess.Common.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryService.Interface;

namespace Foodtopia.ViewComponents.Restaurant
{
    [ViewComponent]
    public class RestaurantsList : ViewComponent    
    {
        private readonly IRestaurantRepository _restaurant;

        public RestaurantsList(IRestaurantRepository restaurant)
        {
            _restaurant = restaurant;
        }

        [ResponseCache(Duration = 3600,Location = ResponseCacheLocation.Any, NoStore = false, VaryByQueryKeys =new []{ "page","quentity" } )]
        public async Task<IViewComponentResult> InvokeAsync(int page, int quentity, string key, int orderBy)
        {
            try
            {
                var restaurants = _restaurant.GetAll().Data;

                if (!string.IsNullOrWhiteSpace(key))
                {
                    restaurants = restaurants
                        .Where(restaurant => restaurant.Title.Contains(key));
                }

                switch (orderBy)
                {
                    case (int)RestaurantOrderBy.CreatedDate:
                    {
                        restaurants = restaurants.OrderByDescending(r => r.CreatedOn);
                        break;
                    }
                    default:
                    {
                        restaurants = restaurants.OrderByDescending(r => r.CreatedOn);
                        break;
                    }
                }

                if (page != 0 && quentity != 0)
                {
                    restaurants = restaurants
                        .Skip((page - 1) * quentity)
                        .Take(quentity);
                }

                var result = await restaurants.ToListAsync();

                return !result.Any() ? null : View(restaurants);
            }
            catch (Exception e)
            {
                return View(new ApiResult<JsonResult>
                {
                    Success = false,
                    Data = null,
                    Info = "",
                    Exception = e,
                    Message = "رکوردی پیدا نشد"
                });
            }
        }
    }
}
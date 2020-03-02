using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantFoodRatingValidation : GenericValidation<RestaurantFoodReating>, IRestaurantFoodRatingValidation
    {
        public RestaurantFoodRatingValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantFoodValidation : GenericValidation<RestaurantFood>, IRestaurantFoodValidation
    {
        public RestaurantFoodValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
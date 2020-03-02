using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantFoodImageValidation : GenericValidation<RestaurantFoodImage>, IRestaurantFoodImageValidation
    {
        public RestaurantFoodImageValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
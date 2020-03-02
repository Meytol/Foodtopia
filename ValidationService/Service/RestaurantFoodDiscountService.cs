using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantFoodDiscountValidation : GenericValidation<RestaurantFoodDiscount>, IRestaurantFoodDiscountValidation
    {
        public RestaurantFoodDiscountValidation(DatabaseContext context)
            :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class CartRestaurantFoodValidation : GenericValidation<CartRestaurantFood>, ICartRestaurantFoodValidation
    {
        public CartRestaurantFoodValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
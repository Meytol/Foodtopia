using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantTypeValidation : GenericValidation<RestaurantType>, IRestaurantTypeValidation
    {
        public RestaurantTypeValidation(DatabaseContext context)
        :base(context)
        {
            
        }   
    }
}
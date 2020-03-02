using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantUserValidation : GenericValidation<RestaurantUser>, IRestaurantUserValidation
    {
        public RestaurantUserValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
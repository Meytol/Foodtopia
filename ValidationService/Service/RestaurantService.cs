using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantValidation : GenericValidation<Restaurant>, IRestaurantValidation
    {
        public RestaurantValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
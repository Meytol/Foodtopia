using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RestaurantFoodCommentValidation : GenericValidation<RestaurantFoodComment>, IRestaurantFoodCommentValidation
    {
        public RestaurantFoodCommentValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantFoodDiscountRepository : GenericRepository<RestaurantFoodDiscount>, IRestaurantFoodDiscountRepository
    {
        public RestaurantFoodDiscountRepository(DatabaseContext context, IRestaurantFoodDiscountValidation validation)
            :base(context, validation)
        {
            
        }
    }
}
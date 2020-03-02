using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantFoodRepository : GenericRepository<RestaurantFood>, IRestaurantFoodRepository
    {
        public RestaurantFoodRepository(DatabaseContext context, IRestaurantFoodValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
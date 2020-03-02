using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantFoodImageRepository : GenericRepository<RestaurantFoodImage>, IRestaurantFoodImageRepository
    {
        public RestaurantFoodImageRepository(DatabaseContext context, IRestaurantFoodImageValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
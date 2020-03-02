using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantUserRepository : GenericRepository<RestaurantUser>, IRestaurantUserRepository
    {
        public RestaurantUserRepository(DatabaseContext context, IRestaurantUserValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
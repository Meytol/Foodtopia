using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantTypeRepository : GenericRepository<RestaurantType>, IRestaurantTypeRepository
    {
        public RestaurantTypeRepository(DatabaseContext context, IRestaurantTypeValidation validation)
        :base(context, validation)
        {
            
        }   
    }
}
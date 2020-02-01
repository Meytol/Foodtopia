using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantTypeService : GenericRepository<RestaurantType>, IRestaurantTypeService
    {
        public RestaurantTypeService(DatabaseContext context)
        :base(context)
        {
            
        }   
    }
}
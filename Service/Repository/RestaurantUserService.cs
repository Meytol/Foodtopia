using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantUserService : GenericRepository<RestaurantUser>, IRestaurantUserService
    {
        public RestaurantUserService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
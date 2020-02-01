using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantService : GenericRepository<Restaurant>, IRestaurantService
    {
        public RestaurantService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantFoodService : GenericRepository<RestaurantFood>, IRestaurantFoodService
    {
        public RestaurantFoodService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantFoodImageService : GenericRepository<RestaurantFoodImage>, IRestaurantFoodImageService
    {
        public RestaurantFoodImageService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
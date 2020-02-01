using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantFoodRatingService : GenericRepository<RestaurantFoodReating>, IRestaurantFoodRatingService
    {
        public RestaurantFoodRatingService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantFoodRatingRepository : GenericRepository<RestaurantFoodRating>, IRestaurantFoodRatingRepository
    {
        public RestaurantFoodRatingRepository(DatabaseContext context, IRestaurantFoodRatingValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
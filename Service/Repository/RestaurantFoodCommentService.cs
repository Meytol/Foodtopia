using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantFoodCommentService : GenericRepository<RestaurantFoodComment>, IRestaurantFoodCommentService
    {
        public RestaurantFoodCommentService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RestaurantFoodCommentRepository : GenericRepository<RestaurantFoodComment>, IRestaurantFoodCommentRepository
    {
        public RestaurantFoodCommentRepository(DatabaseContext context, IRestaurantFoodCommentValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
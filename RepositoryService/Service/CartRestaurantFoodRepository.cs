using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class CartRestaurantFoodRepository : GenericRepository<CartRestaurantFood>, ICartRestaurantFoodRepository
    {
        public CartRestaurantFoodRepository(DatabaseContext context, ICartRestaurantFoodValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
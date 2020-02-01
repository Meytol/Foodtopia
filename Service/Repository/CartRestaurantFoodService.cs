using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class CartRestaurantFoodService : GenericRepository<CartRestaurantFood>,ICartRestaurantFoodService
    {
        public CartRestaurantFoodService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RestaurantFoodDiscountService : GenericRepository<RestaurantFoodDiscount>, IRestaurantFoodDiscountService
    {
        public RestaurantFoodDiscountService(DatabaseContext context)
            :base(context)
        {
            
        }
    }
}
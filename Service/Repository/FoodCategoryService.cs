using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class FoodCategoryService : GenericRepository<FoodCategory>, IFoodCategoryService
    {
        public FoodCategoryService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
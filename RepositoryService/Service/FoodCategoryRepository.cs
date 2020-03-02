using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class FoodCategoryRepository : GenericRepository<FoodCategory>, IFoodCategoryRepository
    {
        public FoodCategoryRepository(DatabaseContext context, IFoodCategoryValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
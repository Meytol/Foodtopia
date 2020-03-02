using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public FoodRepository(DatabaseContext context, IFoodValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
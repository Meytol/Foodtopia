using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class FoodTypeRepository : GenericRepository<FoodType>, IFoodTypeRepository
    {
        public FoodTypeRepository(DatabaseContext context, IFoodTypeValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
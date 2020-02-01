using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class FoodTypeService : GenericRepository<FoodType>, IFoodTypeService
    {
        public FoodTypeService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
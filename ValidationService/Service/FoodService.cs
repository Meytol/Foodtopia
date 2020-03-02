using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class FoodValidation : GenericValidation<Food>, IFoodValidation
    {
        public FoodValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
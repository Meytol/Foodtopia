using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class FoodTypeValidation : GenericValidation<FoodType>, IFoodTypeValidation
    {
        public FoodTypeValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
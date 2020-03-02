using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class FoodCategoryValidation : GenericValidation<FoodCategory>, IFoodCategoryValidation
    {
        public FoodCategoryValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
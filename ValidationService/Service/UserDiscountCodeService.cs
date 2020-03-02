using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class UserDiscountCodeValidation : GenericValidation<UserDiscountCode>, IUserDiscountCodeValidation
    {
        public UserDiscountCodeValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
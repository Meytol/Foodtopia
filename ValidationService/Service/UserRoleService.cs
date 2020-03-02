using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class UserRoleValidation : GenericValidation<UserRole>, IUserRoleValidation
    {
        public UserRoleValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RoleActionValidation : GenericValidation<RoleAction>, IRoleActionValidation
    {
        public RoleActionValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
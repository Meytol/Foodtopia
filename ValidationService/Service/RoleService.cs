using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class RoleValidation : GenericValidation<Role>, IRoleValidation
    {
        public RoleValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
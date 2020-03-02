using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class ApplicationActionValidation : GenericValidation<ApplicationAction>, IApplicationActionValidation
    {
        public ApplicationActionValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
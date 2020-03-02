using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class SmsUserValidation : GenericValidation<SmsUser>, ISmsUserValidation
    {
        public SmsUserValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
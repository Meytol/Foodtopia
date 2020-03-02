using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class SmsValidation : GenericValidation<Sms>, ISmsValidation
    {
        public SmsValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
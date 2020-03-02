using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class EmailUserValidation : GenericValidation<EmailUser>, IEmailUserValidation
    {
        public EmailUserValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
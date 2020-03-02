using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class EmailValidation : GenericValidation<Email>, IEmailValidation
    {
        public EmailValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
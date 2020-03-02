using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class UserValidation : GenericValidation<User>, IUserValidation
    {
        public UserValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
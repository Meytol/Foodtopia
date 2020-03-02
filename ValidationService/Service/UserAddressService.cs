using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class UserAddressValidation : GenericValidation<UserAddress>, IUserAddressValidation
    {
        public UserAddressValidation(DatabaseContext context)
        :base(context)
        {
            
        }   
    }
}
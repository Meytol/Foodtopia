using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class CartValidation : GenericValidation<Cart>, ICartValidation
    {
        public CartValidation(DatabaseContext context)
            : base(context)
        {

        }
    }
}

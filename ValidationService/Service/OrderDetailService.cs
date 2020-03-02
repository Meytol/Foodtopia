using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class OrderDetailValidation : GenericValidation<OrderDetail>, IOrderDetailValidation
    {
        public OrderDetailValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
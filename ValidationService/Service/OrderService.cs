using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class OrderValidation : GenericValidation<Order>, IOrderValidation
    {
        public OrderValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
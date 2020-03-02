using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DatabaseContext context, IOrderDetailValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
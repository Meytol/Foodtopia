using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class OrderDetailService : GenericRepository<OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
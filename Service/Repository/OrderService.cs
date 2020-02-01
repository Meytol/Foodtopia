using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class OrderService : GenericRepository<Order>, IOrderService
    {
        public OrderService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
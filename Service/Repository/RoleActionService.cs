using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RoleActionService : GenericRepository<RoleAction>, IRoleActionService
    {
        public RoleActionService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
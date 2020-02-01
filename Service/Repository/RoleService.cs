using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class RoleService : GenericRepository<Role>, IRoleService
    {
        public RoleService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class UserRoleService : GenericRepository<UserRole>, IUserRoleService
    {
        public UserRoleService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
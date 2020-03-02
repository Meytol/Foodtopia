using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class RoleActionRepository : GenericRepository<RoleAction>, IRoleActionRepository
    {
        public RoleActionRepository(DatabaseContext context, IRoleActionValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
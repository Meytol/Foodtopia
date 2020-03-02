using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class ApplicationActionRepository : GenericRepository<ApplicationAction>, IApplicationActionRepository
    {
        
        public ApplicationActionRepository(DatabaseContext context, IApplicationActionValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
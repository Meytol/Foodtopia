using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class ApplicationActionService : GenericRepository<ApplicationAction>, IApplicationActionService
    {
        public ApplicationActionService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
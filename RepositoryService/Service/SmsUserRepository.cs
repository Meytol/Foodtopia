using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class SmsUserRepository : GenericRepository<SmsUser>, ISmsUserRepository
    {
        public SmsUserRepository(DatabaseContext context, ISmsUserValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
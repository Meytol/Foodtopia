using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class SmsRepository : GenericRepository<Sms>, ISmsRepository
    {
        public SmsRepository(DatabaseContext context, ISmsValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
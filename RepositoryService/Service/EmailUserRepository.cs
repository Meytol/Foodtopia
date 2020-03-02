using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class EmailUserRepository : GenericRepository<EmailUser>, IEmailUserRepository
    {
        public EmailUserRepository(DatabaseContext context, IEmailUserValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
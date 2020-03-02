using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(DatabaseContext context, IEmailValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
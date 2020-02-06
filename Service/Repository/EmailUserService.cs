using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class EmailUserService : GenericRepository<EmailUser>, IEmailUserService
    {
        public EmailUserService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
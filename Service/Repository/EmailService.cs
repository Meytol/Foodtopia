using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class EmailService : GenericRepository<Email>, IEmailSerivce
    {
        public EmailService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
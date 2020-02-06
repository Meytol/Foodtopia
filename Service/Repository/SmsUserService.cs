using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class SmsUserService : GenericRepository<SmsUser>, ISmsUserService
    {
        public SmsUserService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
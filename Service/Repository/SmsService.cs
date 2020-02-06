using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class SmsService : GenericRepository<Sms>, ISmsService
    {
        public SmsService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
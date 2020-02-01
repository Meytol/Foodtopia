using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class UserDiscountCodeService : GenericRepository<UserDiscountCode>, IUserDiscountCodeService
    {
        public UserDiscountCodeService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
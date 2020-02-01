using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class UserAddressService : GenericRepository<UserAddress>, IUserAddressService
    {
        public UserAddressService(DatabaseContext context)
        :base(context)
        {
            
        }   
    }
}
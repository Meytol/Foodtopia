using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class UserDiscountCodeRepository : GenericRepository<UserDiscountCode>, IUserDiscountCodeRepository
    {
        public UserDiscountCodeRepository(DatabaseContext context, IUserDiscountCodeValidation validation)
        :base(context, validation)
        {
            
        }
    }
}
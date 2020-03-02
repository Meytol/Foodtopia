using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(DatabaseContext context, ICartValidation validation)
            : base(context, validation)
        {

        }
    }
}

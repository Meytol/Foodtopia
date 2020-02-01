using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repository
{
    public class CartService : GenericRepository<Cart> ,ICartService
    {
        public CartService(DatabaseContext _context)
            :base(_context)
        {

        }
    }
}

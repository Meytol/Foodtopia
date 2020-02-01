﻿using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class CartService : GenericRepository<Cart>, ICartService
    {
        public CartService(DatabaseContext context)
            : base(context)
        {

        }
    }
}

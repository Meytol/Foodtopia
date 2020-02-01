﻿using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class UserService : GenericRepository<User>, IUserService
    {
        public UserService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
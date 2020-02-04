﻿using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class FoodService : GenericRepository<Food>, IFoodService 
    {
        public FoodService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}
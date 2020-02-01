using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Model;

namespace DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        #region DbSet

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantFood> RestaurantFoods { get; set; }
        public DbSet<RestaurantFoodComment> RestaurantFoodComments { get; set; }
        public DbSet<RestaurantFoodReating> RestaurantFoodReatings { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        #endregion
    }
}

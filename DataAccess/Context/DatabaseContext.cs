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

        public DbSet<ApplicationAction> ApplicationActions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartRestaurantFood> CartRestaurantFoods { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantFood> RestaurantFoods { get; set; }
        public DbSet<RestaurantFoodComment> RestaurantFoodComments { get; set; }
        public DbSet<RestaurantFoodDiscount> RestaurantFoodDiscounts { get; set; }
        public DbSet<RestaurantFoodImage> RestaurantFoodImages { get; set; }
        public DbSet<RestaurantFoodReating> RestaurantFoodReatings { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion
    }
}

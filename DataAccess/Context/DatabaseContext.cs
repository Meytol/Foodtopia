using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Model;
// ReSharper disable UnusedMember.Global

namespace DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        #region DbSet

        public DbSet<ApplicationAction> ApplicationActions { get; set; }
        public DbSet<AuthenticationCode> AuthenticationCodes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartRestaurantFood> CartRestaurantFoods { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailUser> EmailUsers { get; set; }
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
        public DbSet<RestaurantFoodRating> RestaurantFoodReatings { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Sms> Smses { get; set; }
        public DbSet<SmsUser> SmsUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Validation



            #endregion

            #region Relations

            #region IAuditable

            //Cerated by
            modelBuilder.Entity<User>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.UserCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<ApplicationAction>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.ApplicationActionsCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<AuthenticationCode>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.AuthenticationCodeCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Cart>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CartCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<CartRestaurantFood>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CartRestaurantFoodCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<City>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CityCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Email>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.EmailCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<EmailUser>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.EmailUserCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Food>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.FoodCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<FoodCategory>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.FoodCategoryCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<FoodType>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.FoodTypeCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.OrderCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.OrderDetailCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Province>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.ProvinceCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantFood>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantFoodCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantFoodComment>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantFoodCommentCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantFoodDiscount>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantFoodDiscountCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantFoodImage>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantFoodImageCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantFoodRating>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantFoodRatingCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantType>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantTypeCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RestaurantUser>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RestaurantUserCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Role>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RoleCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<RoleAction>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.RoleActionCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<Sms>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.SmsCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<SmsUser>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.SmsUserCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<UserAddress>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.UserAddressCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<UserDiscountCode>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.UserDiscountCodeCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.UserRoleCreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedByUserId);

            //Updated by
            modelBuilder.Entity<User>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UserUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<ApplicationAction>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.ApplicationActionsUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<AuthenticationCode>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.AuthenticationCodeUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Cart>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.CartUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<CartRestaurantFood>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.CartRestaurantFoodUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<City>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.CityUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Email>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.EmailUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<EmailUser>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.EmailUserUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Food>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.FoodUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<FoodCategory>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.FoodCategoryUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<FoodType>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.FoodTypeUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.OrderUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.OrderDetailUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Province>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.ProvinceUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantFood>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantFoodUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantFoodComment>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantFoodCommentUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantFoodDiscount>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantFoodDiscountUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantFoodImage>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantFoodImageUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantFoodRating>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantFoodRatingUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantType>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantTypeUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RestaurantUser>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RestaurantUserUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Role>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RoleUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<RoleAction>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.RoleActionUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<Sms>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.SmsUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<SmsUser>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.SmsUserUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<UserAddress>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UserAddressUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<UserDiscountCode>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UserDiscountCodeUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UserRoleUpdatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UpdatedByUserId);

            //Deleted by
            modelBuilder.Entity<User>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.UserDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<ApplicationAction>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.ApplicationActionsDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<AuthenticationCode>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.AuthenticationCodeDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Cart>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.CartDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<CartRestaurantFood>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.CartRestaurantFoodDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<City>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.CityDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Email>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.EmailDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<EmailUser>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.EmailUserDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Food>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.FoodDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<FoodCategory>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.FoodCategoryDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<FoodType>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.FoodTypeDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.OrderDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.OrderDetailDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Province>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.ProvinceDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantFood>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantFoodDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantFoodComment>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantFoodCommentDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantFoodDiscount>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantFoodDiscountDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantFoodImage>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantFoodImageDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantFoodRating>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantFoodRatingDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantType>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantTypeDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RestaurantUser>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RestaurantUserDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Role>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RoleDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<RoleAction>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.RoleActionDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<Sms>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.SmsDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<SmsUser>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.SmsUserDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<UserAddress>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.UserAddressDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<UserDiscountCode>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.UserDiscountCodeDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.DeletedByUser)
                .WithMany(u => u.UserRoleDeletedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.DeletedByUserId);

            //Owner User
            modelBuilder.Entity<User>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.UserOwner)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<ApplicationAction>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.ApplicationActionsOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<AuthenticationCode>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.AuthenticationCodeOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Cart>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.CartOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<CartRestaurantFood>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.CartRestaurantFoodOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<City>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.CityOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Email>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.EmailOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<EmailUser>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.EmailUserOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Food>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.FoodOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<FoodCategory>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.FoodCategoryOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<FoodType>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.FoodTypeOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.OrderOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.OrderDetailOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Province>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.ProvinceOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantFood>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantFoodOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantFoodComment>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantFoodCommentOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantFoodDiscount>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantFoodDiscountOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantFoodImage>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantFoodImageOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantFoodRating>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantFoodRatingOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantType>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantTypeOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RestaurantUser>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RestaurantUserOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Role>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RoleOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<RoleAction>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.RoleActionOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<Sms>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.SmsOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<SmsUser>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.SmsUserOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<UserAddress>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.UserAddressOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<UserDiscountCode>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.UserDiscountCodeOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.OwnerUser)
                .WithMany(u => u.UserRoleOwnerUser)
                .HasForeignKey(e => e.OwnerUserId);

            #endregion

            modelBuilder.Entity<ApplicationAction>()
                .HasOne(e => e.Parent)
                .WithMany(ee => ee.Childs)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ParentId);


            modelBuilder.Entity<CartRestaurantFood>()
                .HasOne(e => e.RestaurantFood)
                .WithMany(ee => ee.CartRestaurantFoods)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantFoodId);

            modelBuilder.Entity<CartRestaurantFood>()
                .HasOne(e => e.Cart)
                .WithMany(ee => ee.CartRestaurantFoods)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CartId);


            modelBuilder.Entity<City>()
                .HasOne(e => e.Province)
                .WithMany(ee => ee.Cities)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ProvinceId);


            modelBuilder.Entity<EmailUser>()
                .HasOne(e => e.Email)
                .WithMany(ee => ee.EmailUsers)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.EmailId);


            modelBuilder.Entity<RestaurantFood>()
                .HasOne(e => e.Food)
                .WithMany(ee => ee.RestaurantFoods)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.FoodId);


            modelBuilder.Entity<FoodType>()
                .HasOne(e => e.Food)
                .WithMany(ee => ee.FoodTypes)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.FoodId);

            modelBuilder.Entity<FoodType>()
                .HasOne(e => e.FoodCategory)
                .WithMany(ee => ee.FoodsTypes)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.FoodCategoryId);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.RestaurantFood)
                .WithMany(ee => ee.OrderDetails)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantFoodId);


            modelBuilder.Entity<Restaurant>()
                .HasOne(e => e.RestaurantType)
                .WithMany(ee => ee.Restaurants)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantTypeId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(e => e.City)
                .WithMany(ee => ee.Restaurants)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CityId);


            modelBuilder.Entity<RestaurantFoodComment>()
                .HasOne(e => e.Parent)
                .WithMany(ee => ee.Childs)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ParentId);


            modelBuilder.Entity<RestaurantFoodDiscount>()
                .HasOne(e => e.RestaurantFood)
                .WithMany(ee => ee.RestaurantFoodDiscounts)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantFoodId);


            modelBuilder.Entity<RestaurantFoodImage>()
                .HasOne(e => e.RestaurantFood)
                .WithMany(ee => ee.RestaurantFoodImages)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantFoodId);


            modelBuilder.Entity<RestaurantFoodRating>()
                .HasOne(e => e.RestaurantFood)
                .WithMany(ee => ee.RestaurantFoodRatings)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantFoodId);


            modelBuilder.Entity<RestaurantUser>()
                .HasOne(e => e.Restaurant)
                .WithMany(ee => ee.RestaurantUsers)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RestaurantId);


            modelBuilder.Entity<RoleAction>()
                .HasOne(e => e.Role)
                .WithMany(ee => ee.RoleActions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<RoleAction>()
                .HasOne(e => e.Action)
                .WithMany(ee => ee.RoleActions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ActionId);


            modelBuilder.Entity<SmsUser>()
                .HasOne(e => e.Sms)
                .WithMany(ee => ee.SmsUsers)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.SmsId);


            modelBuilder.Entity<UserAddress>()
                .HasOne(e => e.City)
                .WithMany(ee => ee.UserAddresses)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CityId);


            modelBuilder.Entity<UserDiscountCode>()
                .HasOne(e => e.EndUser)
                .WithMany(ee => ee.UserDiscountCodes)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.EndUserId);


            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.Role)
                .WithMany(ee => ee.UserRoles)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.User)
                .WithMany(ee => ee.UserRoles)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UserId);

            #endregion
        }

    }
}

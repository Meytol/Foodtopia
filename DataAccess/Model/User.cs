using DataAccess.Common.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class User : IAuditable
    {
        #region IAuditableProperties

        [Key]
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? OwnerUserId { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool IsMale { get; set; }
        public string AvatarImageAddress { get; set; }
        public DateTime LastLogin { get; set; }
        public bool PhonenumberConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsActive { get; set; }
        public bool IsLockout { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public short AccessFailedCount { get; set; }

        [NotMapped]
        public string Fullname => $"{Firstname} {Lastname}";
        
        [NotMapped]
        public string Fullname2 => IsMale ? $"آقای {Firstname} {Lastname}" : $"خانم {Firstname} {Lastname}";

        #region Relations

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        #region IAuditable 

        //Created By
        public ICollection<User> UserCreatedBy { get; set; }
        public ICollection<ApplicationAction> ApplicationActionsCreatedBy { get; set; }
        public ICollection<AuthenticationCode> AuthenticationCodeCreatedBy { get; set; }
        public ICollection<Cart> CartCreatedBy { get; set; }
        public ICollection<CartRestaurantFood> CartRestaurantFoodCreatedBy { get; set; }
        public ICollection<City> CityCreatedBy { get; set; }
        public ICollection<Email> EmailCreatedBy { get; set; }
        public ICollection<EmailUser> EmailUserCreatedBy { get; set; }
        public ICollection<Food> FoodCreatedBy { get; set; }
        public ICollection<FoodCategory> FoodCategoryCreatedBy { get; set; }
        public ICollection<FoodType> FoodTypeCreatedBy { get; set; }
        public ICollection<Order> OrderCreatedBy { get; set; }
        public ICollection<OrderDetail> OrderDetailCreatedBy { get; set; }
        public ICollection<Province> ProvinceCreatedBy { get; set; }
        public ICollection<Restaurant> RestaurantCreatedBy { get; set; }
        public ICollection<RestaurantFood> RestaurantFoodCreatedBy { get; set; }
        public ICollection<RestaurantFoodComment> RestaurantFoodCommentCreatedBy { get; set; }
        public ICollection<RestaurantFoodDiscount> RestaurantFoodDiscountCreatedBy { get; set; }
        public ICollection<RestaurantFoodImage> RestaurantFoodImageCreatedBy { get; set; }
        public ICollection<RestaurantFoodRating> RestaurantFoodRatingCreatedBy { get; set; }
        public ICollection<RestaurantType> RestaurantTypeCreatedBy { get; set; }
        public ICollection<RestaurantUser> RestaurantUserCreatedBy { get; set; }
        public ICollection<Role> RoleCreatedBy { get; set; }
        public ICollection<RoleAction> RoleActionCreatedBy { get; set; }
        public ICollection<Sms> SmsCreatedBy { get; set; }
        public ICollection<SmsUser> SmsUserCreatedBy { get; set; }
        public ICollection<UserAddress> UserAddressCreatedBy { get; set; }
        public ICollection<UserDiscountCode> UserDiscountCodeCreatedBy { get; set; }
        public ICollection<UserRole> UserRoleCreatedBy { get; set; }

        //Updated By
        public ICollection<User> UserUpdatedBy { get; set; }
        public ICollection<ApplicationAction> ApplicationActionsUpdatedBy { get; set; }
        public ICollection<AuthenticationCode> AuthenticationCodeUpdatedBy { get; set; }
        public ICollection<Cart> CartUpdatedBy { get; set; }
        public ICollection<CartRestaurantFood> CartRestaurantFoodUpdatedBy { get; set; }
        public ICollection<City> CityUpdatedBy { get; set; }
        public ICollection<Email> EmailUpdatedBy { get; set; }
        public ICollection<EmailUser> EmailUserUpdatedBy { get; set; }
        public ICollection<Food> FoodUpdatedBy { get; set; }
        public ICollection<FoodCategory> FoodCategoryUpdatedBy { get; set; }
        public ICollection<FoodType> FoodTypeUpdatedBy { get; set; }
        public ICollection<Order> OrderUpdatedBy { get; set; }
        public ICollection<OrderDetail> OrderDetailUpdatedBy { get; set; }
        public ICollection<Province> ProvinceUpdatedBy { get; set; }
        public ICollection<Restaurant> RestaurantUpdatedBy { get; set; }
        public ICollection<RestaurantFood> RestaurantFoodUpdatedBy { get; set; }
        public ICollection<RestaurantFoodComment> RestaurantFoodCommentUpdatedBy { get; set; }
        public ICollection<RestaurantFoodDiscount> RestaurantFoodDiscountUpdatedBy { get; set; }
        public ICollection<RestaurantFoodImage> RestaurantFoodImageUpdatedBy { get; set; }
        public ICollection<RestaurantFoodRating> RestaurantFoodRatingUpdatedBy { get; set; }
        public ICollection<RestaurantType> RestaurantTypeUpdatedBy { get; set; }
        public ICollection<RestaurantUser> RestaurantUserUpdatedBy { get; set; }
        public ICollection<Role> RoleUpdatedBy { get; set; }
        public ICollection<RoleAction> RoleActionUpdatedBy { get; set; }
        public ICollection<Sms> SmsUpdatedBy { get; set; }
        public ICollection<SmsUser> SmsUserUpdatedBy { get; set; }
        public ICollection<UserAddress> UserAddressUpdatedBy { get; set; }
        public ICollection<UserDiscountCode> UserDiscountCodeUpdatedBy { get; set; }
        public ICollection<UserRole> UserRoleUpdatedBy { get; set; }

        //Deleted By
        public ICollection<User> UserDeletedBy { get; set; }
        public ICollection<ApplicationAction> ApplicationActionsDeletedBy { get; set; }
        public ICollection<AuthenticationCode> AuthenticationCodeDeletedBy { get; set; }
        public ICollection<Cart> CartDeletedBy { get; set; }
        public ICollection<CartRestaurantFood> CartRestaurantFoodDeletedBy { get; set; }
        public ICollection<City> CityDeletedBy { get; set; }
        public ICollection<Email> EmailDeletedBy { get; set; }
        public ICollection<EmailUser> EmailUserDeletedBy { get; set; }
        public ICollection<Food> FoodDeletedBy { get; set; }
        public ICollection<FoodCategory> FoodCategoryDeletedBy { get; set; }
        public ICollection<FoodType> FoodTypeDeletedBy { get; set; }
        public ICollection<Order> OrderDeletedBy { get; set; }
        public ICollection<OrderDetail> OrderDetailDeletedBy { get; set; }
        public ICollection<Province> ProvinceDeletedBy { get; set; }
        public ICollection<Restaurant> RestaurantDeletedBy { get; set; }
        public ICollection<RestaurantFood> RestaurantFoodDeletedBy { get; set; }
        public ICollection<RestaurantFoodComment> RestaurantFoodCommentDeletedBy { get; set; }
        public ICollection<RestaurantFoodDiscount> RestaurantFoodDiscountDeletedBy { get; set; }
        public ICollection<RestaurantFoodImage> RestaurantFoodImageDeletedBy { get; set; }
        public ICollection<RestaurantFoodRating> RestaurantFoodRatingDeletedBy { get; set; }
        public ICollection<RestaurantType> RestaurantTypeDeletedBy { get; set; }
        public ICollection<RestaurantUser> RestaurantUserDeletedBy { get; set; }
        public ICollection<Role> RoleDeletedBy { get; set; }
        public ICollection<RoleAction> RoleActionDeletedBy { get; set; }
        public ICollection<Sms> SmsDeletedBy { get; set; }
        public ICollection<SmsUser> SmsUserDeletedBy { get; set; }
        public ICollection<UserAddress> UserAddressDeletedBy { get; set; }
        public ICollection<UserDiscountCode> UserDiscountCodeDeletedBy { get; set; }
        public ICollection<UserRole> UserRoleDeletedBy { get; set; }

        //Owner
        public ICollection<User> UserOwner { get; set; }
        public ICollection<ApplicationAction> ApplicationActionsOwnerUser { get; set; }
        public ICollection<AuthenticationCode> AuthenticationCodeOwnerUser { get; set; }
        public ICollection<Cart> CartOwnerUser { get; set; }
        public ICollection<CartRestaurantFood> CartRestaurantFoodOwnerUser { get; set; }
        public ICollection<City> CityOwnerUser { get; set; }
        public ICollection<Email> EmailOwnerUser { get; set; }
        public ICollection<EmailUser> EmailUserOwnerUser { get; set; }
        public ICollection<Food> FoodOwnerUser { get; set; }
        public ICollection<FoodCategory> FoodCategoryOwnerUser { get; set; }
        public ICollection<FoodType> FoodTypeOwnerUser { get; set; }
        public ICollection<Order> OrderOwnerUser { get; set; }
        public ICollection<OrderDetail> OrderDetailOwnerUser { get; set; }
        public ICollection<Province> ProvinceOwnerUser { get; set; }
        public ICollection<Restaurant> RestaurantOwnerUser { get; set; }
        public ICollection<RestaurantFood> RestaurantFoodOwnerUser { get; set; }
        public ICollection<RestaurantFoodComment> RestaurantFoodCommentOwnerUser { get; set; }
        public ICollection<RestaurantFoodDiscount> RestaurantFoodDiscountOwnerUser { get; set; }
        public ICollection<RestaurantFoodImage> RestaurantFoodImageOwnerUser { get; set; }
        public ICollection<RestaurantFoodRating> RestaurantFoodRatingOwnerUser { get; set; }
        public ICollection<RestaurantType> RestaurantTypeOwnerUser { get; set; }
        public ICollection<RestaurantUser> RestaurantUserOwnerUser { get; set; }
        public ICollection<Role> RoleOwnerUser { get; set; }
        public ICollection<RoleAction> RoleActionOwnerUser { get; set; }
        public ICollection<Sms> SmsOwnerUser { get; set; }
        public ICollection<SmsUser> SmsUserOwnerUser { get; set; }
        public ICollection<UserAddress> UserAddressOwnerUser { get; set; }
        public ICollection<UserDiscountCode> UserDiscountCodeOwnerUser { get; set; }
        public ICollection<UserRole> UserRoleOwnerUser { get; set; }

        #endregion
        public ICollection<UserDiscountCode> UserDiscountCodes { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }


        #endregion
    }
}

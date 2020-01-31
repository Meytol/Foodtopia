using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Common;
using DataAccess.Common.Enum;

namespace DataAccess.Model
{
    public class RestaurantFoodDiscount : IAuditable
    {
        #region IAuditableProperties

        [Key]
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int OwnerUserId { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        public int RestaurantFoodId { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal? Amount { get; set; }
        public float? Percentage { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int MaxUsage { get; set; }
        public int Usage { get; set; }


        #region Relations

        public RestaurantFood RestaurantFood { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        #endregion
    }
}

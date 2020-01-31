using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class RestaurantFood : IAuditable
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

        public int FoodId { get; set; }
        public TimeSpan MakingTime { get; set; }
        public decimal Price { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(150)]
        public string CustomizeFoodName { get; set; }

        #region Relations

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        public ICollection<RestaurantFoodImage> RestaurantFoodImage { get; set; }
        public Food Food { get; set; }

        #endregion
    }
}

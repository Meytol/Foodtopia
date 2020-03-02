using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Common.Interface;

namespace DataAccess.Model
{
    public class RestaurantFoodImage : IAuditable
    {
        #region IAuditableProperties

        [Key]
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int OwnerUserId { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
        
        [StringLength(250)]
        public string Title { get; set; }
        
        [StringLength(250)]
        public string AltText { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int RestaurantFoodId { get; set; }

        #region Relations

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }
        public RestaurantFood RestaurantFood { get; set; }

        #endregion
    }
}
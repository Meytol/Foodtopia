using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess.Common;

namespace DataAccess.Model
{
    public class CartRestaurantFood : IAuditable
    {
        #region IAuditableProperties

        [Key] public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int OwnerUserId { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        public int CartId { get; set; }
        public int RestaurantFoodId { get; set; }

        #region Relations

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }
        public RestaurantFood RestaurantFood { get; set; }
        public Cart Cart { get; set; }

        #endregion
    }
}
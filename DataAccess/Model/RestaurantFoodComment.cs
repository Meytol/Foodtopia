﻿using DataAccess.Common.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class RestaurantFoodComment : IAuditable
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

        public int IsConfirmed { get; set; }

        [StringLength(1000)]
        public string Text { get; set; }
        public short Score { get; set; }
        public int? ParentId { get; set; }

        #region Relations

        public RestaurantFoodComment Parent { get; set; }
        public ICollection<RestaurantFoodComment> Childs { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        #endregion
    }
}

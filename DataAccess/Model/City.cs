using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Common.Interface;

namespace DataAccess.Model
{
    public class City : IAuditable
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

        public int ProvinceId { get; set; }
        
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(5)]
        public string CityCode { get; set; }

        #region Relations

        public Province Province { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        #endregion
    }
}
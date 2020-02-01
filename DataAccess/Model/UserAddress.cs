using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccess.Common.Interface;

namespace DataAccess.Model
{
    public class UserAddress : IAuditable
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

        public int CityId { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [StringLength(1500)]
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }


        #region Relations

        public City City { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        #endregion
    }
}

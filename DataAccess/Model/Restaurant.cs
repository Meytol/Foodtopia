using DataAccess.Common.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class Restaurant : IAuditable
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

        public string AvaterImageAddress { get; set; }
        public string BannerImageAddress { get; set; }
        public int CityId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }
        public double Longitude { get; set; }
        public double Latitude  { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(10)]
        public string PrimaryPhoneNumber { get; set; }

        [StringLength(10)] 
        public string SecondryPhoneNumber { get; set; }

        [StringLength(11)] 
        public string MobilePhoneNumber { get; set; }
        
        public int RestaurantTypeId { get; set; }

        #region Relations

        public RestaurantType RestaurantType { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }
        public City City { get; set; }

        #endregion
    }
}
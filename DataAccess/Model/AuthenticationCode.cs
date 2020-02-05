using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class AuthenticationCode : IAuditable
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

        [StringLength(10)]
        public string Code { get; set; }
        public Timespan ExpiryDurationTime { get; set; }

        public bool IsUse { get; set; } = false;

        #region Relations

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }
        public ApplicationAction Parent { get; set; }
        public ICollection<RoleAction> RoleActions { get; set; }

        #endregion
    }
}

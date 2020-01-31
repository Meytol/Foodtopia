using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccess.Model;

namespace DataAccess.Common
{
    public interface IAuditable
    {
        [Key]
        int Id { get; set; }

        int CreatedByUserId { get; set; }
        DateTime CreatedOn { get; set; }

        int UpdatedByUserId { get; set; }
        DateTime? UpdatedOn { get; set; }

        int DeletedByUserId { get; set; }
        DateTime? DeletedOn { get; set; }

        int OwnerUserId { get; set; }

        bool IsDeleted { get; set; }

        #region Relations

        User CreatedByUser { get; set; }
        User UpdatedByUser { get; set; }
        User DeletedByUser { get; set; }
        User OwnerUser { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }

        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public int? UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int? DeactivatedByUserId { get; set; }
        public DateTime? DeactivatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}

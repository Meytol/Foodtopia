﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess.Common.Interface;

namespace DataAccess.Model
{
    public class Email : IAuditable
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

        public string Name { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }

        #region Relations

        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        public User DeletedByUser { get; set; }
        public User OwnerUser { get; set; }

        #endregion
    }
}

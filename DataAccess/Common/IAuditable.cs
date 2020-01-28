using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Common
{
    public interface IAuditable
    {
        int Id { get; set; }

        int CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }

        int UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }

        int DeletedBy { get; set; }
        DateTime? DeletedOn { get; set; }

        int OwnerId { get; set; }

        bool IsDeleted { get; set; }

        #region Relations

       

        #endregion
    }
}

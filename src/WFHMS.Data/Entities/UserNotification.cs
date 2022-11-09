using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class UserNotification : BaseEntity
    {
            public int NotificationId { get; set; }

            [ForeignKey("Employee")]
            public virtual int EmployeeId { get; set; }


            public virtual Employee Employee { get; set; }
            public bool IsRead { get; set; }
        
    }
}

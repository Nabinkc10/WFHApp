using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities.Enum;

namespace WFHMS.Data.Entities
{
    public class Employee : BaseEntity
    {
        [StringLength(200)]
        public string FullName { get; set; }
        public int EmployeeCode { get; set; }
        [StringLength(30)]
        public string Gender { get; set; }
        public string? PicturePath { get; set; }
        [StringLength(300)]
        public string Address { get; set; }
         
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        public virtual ICollection<ApplyForWFH> ApplyForWFHs { get; set; }
        //public virtual ICollection<Worklog> Worklogs { get; set; }
        //public virtual ICollection<Request> Requests { get; set; }
        //public virtual ICollection<UserNotification> UserNotifications { get; set; }

    }
}

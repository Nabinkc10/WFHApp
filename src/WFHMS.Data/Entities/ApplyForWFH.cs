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
    public class ApplyForWFH : BaseEntity
    {
        
        [StringLength(30)]
        public string FullName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public String LeaveType { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        [StringLength(300)]
        public string Reason { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public string? Name { get; set; }

        public virtual Department Departments{ get; set; }

        //public IEnumerable<ApplyForWFH> ApplyForWFHs { get; set; }

    }
}

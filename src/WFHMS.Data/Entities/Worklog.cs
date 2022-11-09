using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class Worklog : BaseEntity
    {
        [StringLength(500)]
        public string WorkLog { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string ApprovedBy { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public string RejectedBy { get; set; }
    }
}

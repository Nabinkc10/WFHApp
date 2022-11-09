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
    public class Request : BaseEntity
    {
        public Status Status { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Types Types { get; set; }
        
        [StringLength(200)]
        public string ApprovedBy { get; set; }

        [StringLength(400)]
        public string Remarks { get; set; }




    }
}

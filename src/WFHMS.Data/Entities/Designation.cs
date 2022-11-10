using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class Designation : BaseEntity
    {
       
        [StringLength(200)]
        public string DesignationName { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
       

        public virtual Department Department { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}

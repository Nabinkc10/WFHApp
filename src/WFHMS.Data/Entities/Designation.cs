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
        public int Id { get; set; }
        [StringLength(200)]
        public string DesignationName { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]

        public virtual Department Department { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}

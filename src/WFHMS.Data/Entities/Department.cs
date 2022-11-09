using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual ICollection<Department> Departments { get; set; }
    }
}

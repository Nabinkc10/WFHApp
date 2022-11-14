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
        
        [StringLength(200)]
        public string Name { get; set; }
      
        public virtual ICollection<Designation> Designations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class Notification : BaseEntity
    {
        public DateTime date { get; set; }
        [StringLength(200)]
        public string Notice { get; set; }
    }
}

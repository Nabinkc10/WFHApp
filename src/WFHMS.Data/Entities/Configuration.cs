using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class Configuration : BaseEntity
    {
        [StringLength(20)]
        public string Key { get; set; }
        [StringLength(30)]
        public string Value { get; set; }
    }
}

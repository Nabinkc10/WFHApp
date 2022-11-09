using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Models.ViewModel
{
    public class DesignationListViewModel
    {
        public int Id { get; set; }
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<DesignationListViewModel>? Designation{ get; set; }
    }
    public class DesignationCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<DesignationListViewModel>? Designation { get; set; }
    }
}

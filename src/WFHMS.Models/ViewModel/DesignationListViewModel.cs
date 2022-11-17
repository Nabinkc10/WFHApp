using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string DepartmentName { get; set; }
        public IEnumerable<SelectListItem>? Department { get; set; }
        public IEnumerable<DesignationListViewModel>? Designation { get; set; }
    }
    public class DesignationCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem>? Department { get; set; }
    }
}

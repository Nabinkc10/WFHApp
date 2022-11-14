using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities.Enum;
using WFHMS.Data.Entities;

namespace WFHMS.Models.ViewModel
{
    public class ApplyForWFHListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public String LeaveType { get; set; }
        public int? EmployeeId { get; set; }
        public string Reason { get; set; }
        
        //public string Name { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Department { get; set; }
        public IEnumerable<SelectListItem> Employee { get; set; }
        public IEnumerable<ApplyForWFHListViewModel>? ApplyForWFHs { get; set; }
    }
    public class ApplyForWFHCreateViewModel
    {
        // public ApplyForWFH ApplyForWFH { get; set; }
        public int Id { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Name is Required")]
        public string FullName { get; set; }
         public DateTime From { get; set; }
        public DateTime To { get; set; }

        public string LeaveType { get; set; }

     
        public int? EmployeeId { get; set;}
        [StringLength(300)]
        public string Reason { get; set; }
        public int DepartmentId { get; set;}
        //public string Name { get; set; }
        public IEnumerable<SelectListItem> Department { get; set; }

        public IEnumerable<SelectListItem> Employee { get; set; }

        //public IEnumerable<ApplyForWFHCreateViewModel> ApplyForWFHs { get; set; }


    }
}

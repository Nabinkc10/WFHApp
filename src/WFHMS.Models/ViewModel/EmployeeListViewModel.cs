using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities.Enum;

namespace WFHMS.Models.ViewModel
{
    public class EmployeeListViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Use letters only please")]
        public string FullName { get; set; }
        public int EmployeeCode { get; set; }
        [StringLength(30)]
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        [StringLength(300)]
        public string Address { get; set; }

        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Phone Number is Required!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("(?:\\(?\\+977\\)?)?[9][6-9]\\d{8}|01[-]?[0-9]{7}", ErrorMessage ="Phone number NOT Valid!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is Required!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(300)]
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string DesignationName { get; set; }
        public int DesignationId { get; set; }
        public IEnumerable<SelectListItem> Department { get; set; }
        public IEnumerable<SelectListItem> Designation { get; set; }
        public IEnumerable<EmployeeListViewModel>? Employee { get; set; }

    }
    public class EmployeeCreateViewModel
    {

        [StringLength(50)]
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Use letters only please")]
        public string FullName { get; set; }
        public int EmployeeCode { get; set; }
        [StringLength(30)]
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        [StringLength(300)]
        public string Address { get; set; }

        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Phone Number is Required!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("(?:\\(?\\+977\\)?)?[9][6-9]\\d{8}|01[-]?[0-9]{7}", ErrorMessage = "Phone number NOT Valid!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is Required!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(300)]
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string DesignationName { get; set; }
        public int DesignationId { get; set; }
        public IEnumerable<SelectListItem> Department { get; set; }
        public IEnumerable<SelectListItem> Designation { get; set; }
        public IEnumerable<EmployeeCreateViewModel> Employee { get; set; }


    }
}

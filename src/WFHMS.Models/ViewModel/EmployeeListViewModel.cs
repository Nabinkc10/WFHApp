using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Models.ViewModel
{
    public class EmployeeListViewModel
    {

        [StringLength(200)]
        public string FullName { get; set; }
        public int EmployeeCode { get; set; }
        [StringLength(30)]
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        [StringLength(300)]
        public string Address { get; set; }

        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        public int DesignationId { get; set; }
        public IEnumerable<EmployeeListViewModel>? Employee { get; set; }

    }
    public class EmployeeCreateViewModel
    {

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(200)]
        public string FullName { get; set; }
        public int EmployeeCode { get; set; }
        [StringLength(30)]
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        [StringLength(300)]
        public string Address { get; set; }

        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        public int DesignationId { get; set; }
   

    }
}

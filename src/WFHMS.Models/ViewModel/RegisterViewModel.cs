using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WFHMS.Models.ViewModel
{
    public class RegisterViewModel
    {
        //    [Required]
        //    public string Name { get; set; }

        //    [Required]
        //    public string PhoneNumber { get ; set; }

        //    [Required]
        //    public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        public string Email { get; set; }

      
        //public int DepartmentId { get; set; }
        //public IEnumerable<SelectListItem> Departments { get; set; }

        //public int DesignationId { get; set; }
        //public IEnumerable<SelectListItem> Designations { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name ="Confirm-Password")]
        [Compare("Password", ErrorMessage="Password and confirmation Password donot Match")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }

    }
}

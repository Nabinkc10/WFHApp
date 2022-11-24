using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WFHMS.Models.ViewModel
{
    public class DepartmentCreateViewModel
    {


        [Required(ErrorMessage = "DepartmentName Is Required!")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string Name{ get; set; }
        //public int? DepartmentId { get; set; }
    }
    public class DepartmentListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "DepartmentName Is Required!")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string Name { get; set; }
        //public int? DepartmentId { get; set; }
        public IEnumerable<DepartmentListViewModel> Department { get; set; }

    }

}
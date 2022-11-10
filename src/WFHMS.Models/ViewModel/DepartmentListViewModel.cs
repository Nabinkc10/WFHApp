using System.ComponentModel.DataAnnotations;
namespace WFHMS.Models.ViewModel
{
    public class DepartmentCreateViewModel
    {

         
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string Name{ get; set; }
        //public int? DepartmentId { get; set; }
       
        

    }
    public class DepartmentListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int? DepartmentId { get; set; }
        public IEnumerable<DepartmentListViewModel> Department { get; set; }

    }

}
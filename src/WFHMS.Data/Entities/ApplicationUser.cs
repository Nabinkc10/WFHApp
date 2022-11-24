using Microsoft.AspNetCore.Identity;

namespace WFHMS.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
       
    }
}

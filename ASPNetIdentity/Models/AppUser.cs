using Microsoft.AspNetCore.Identity;

namespace ASPNetIdentity.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
    }
}

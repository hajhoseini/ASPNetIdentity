﻿using Microsoft.AspNetCore.Identity;

namespace ASPNetIdentity.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
    }

    public class AppRole : IdentityRole<int>
    {

    }
}

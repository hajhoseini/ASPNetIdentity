﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNetIdentity.Models
{
    public class AppIdentityDbContext : /*IdentityDbContext<AppUser, AppRole, int>*/IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}

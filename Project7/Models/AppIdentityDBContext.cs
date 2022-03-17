using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        // constructor that sets up options for context file
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}

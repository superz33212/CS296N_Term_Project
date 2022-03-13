using CS296N_Term_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace CS296N_Term_Project.Models
{
    public class AdminVM
    {
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
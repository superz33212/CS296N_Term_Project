using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CS296N_Term_Project.Models
{
    public class AppUser : IdentityUser
    {
        public string ScreenName { get; set; }
        //TODO: User likes?
        //public List<Likes> LikedPosts { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}

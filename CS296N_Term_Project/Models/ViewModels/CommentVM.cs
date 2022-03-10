using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS296N_Term_Project.Models
{
    public class Comment
    {
        public string Description { get; set; }
        public int Likes { get; set; }
        public int PostId { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}

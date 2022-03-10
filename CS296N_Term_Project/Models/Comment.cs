using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS296N_Term_Project.Models
{
    public class CommentVM
    {
        //TODO: Properly set up data annotations
        public int CommentId { get; set; }
        //TODO: Set up user and change this to a user obj
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string ImagePath { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}

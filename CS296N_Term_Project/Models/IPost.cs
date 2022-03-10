using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS296N_Term_Project.Models
{
    public interface IPost
    {
        //TODO: Properly set up data annotations
        public int PostId { get; set; }
        //TODO: Set up user and change this to a user obj
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string Path { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

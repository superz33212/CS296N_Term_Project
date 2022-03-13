using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS296N_Term_Project.Models
{
    public interface IComment
    {
        //TODO: Properly set up data annotations
        [Key]
        public int CommentId { get; set; }
        public AppUser User { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}

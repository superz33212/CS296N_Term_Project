using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS296N_Term_Project.Models
{
    public class ImagePost : IPost
    {
        //TODO: Properly set up data annotations
        [Key]
        public int PostId { get; set; }
        public AppUser User { get; set; }
        public string PosterName { get; set; }
        [Required(ErrorMessage = "You must enter the name of the title.")]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string Path { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

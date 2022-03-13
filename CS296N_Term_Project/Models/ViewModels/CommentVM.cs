using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS296N_Term_Project.Models
{
    public class CommentVM
    {
        public string Description { get; set; }
        public int PostId { get; set; }
        public ImagePost imagePost { get; set; }
        public VideoPost videoPost { get; set; }
    }
}

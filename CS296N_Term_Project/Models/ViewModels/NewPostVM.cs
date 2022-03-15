using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.ViewModels
{
    public class NewPostVM
    {
        [Required]
        public BufferedSingleFileUploadPhysical Image { get; set; }
        public ImagePost imagePost { get; set; }
        public VideoPost videoPost { get; set; }
    }
}

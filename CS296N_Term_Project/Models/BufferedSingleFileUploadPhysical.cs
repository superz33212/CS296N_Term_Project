using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models
{
    public class BufferedSingleFileUploadPhysical
    {
        public IFormFile FormFile { get; set; }

        public string Note { get; set; }
    }
}

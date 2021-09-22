using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Samples.Web.Models.File
{
    public class UploadViewModel
    {
        public List<IFormFile> FileBases { get; set; }
    }
}

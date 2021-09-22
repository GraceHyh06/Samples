using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Samples.Web.Models.File;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Samples.Web.Controllers
{
    public class FileController: Controller
    {
        string FileDownloadBase = @"c:\filetransfer";
        string FileUploadBase = @"C:\filetransfer";
        public async Task<IActionResult> List()
        {
            var dir = new DirectoryInfo(FileDownloadBase);
            var files = dir.GetFiles().Select(f=>new FileItem(f.Name,f.Length));
            //var files = Directory.GetFiles(FileDownloadBase).Select(p=>Path.GetFileName(p)).ToList();

            return View(files);
        }

        public async Task<FileStreamResult> GetFile(string file)
        {
            var stream = new FileStream(Path.Combine(FileDownloadBase,file),FileMode.Open, FileAccess.Read);
            var result = File(stream, "application/octet-stream");
            result.FileDownloadName = file;
            return result;
        }

        public async Task<IActionResult> Upload()
        {
            var model = new UploadViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadViewModel upload)
        {
            foreach (var formFile in upload.FileBases)
            {
                //var formFile = upload.FileBase;
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(FileUploadBase,formFile.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            //return Ok(new { count = files.Count, size }); 
            return View();
        }
    }
}

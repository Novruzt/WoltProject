using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Things
{
    public static class FileService
    {

        public static string SaveImage(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string fileName = Guid.NewGuid() + "-" + file.FileName;
            string relativePath = "images";
            string directoryPath = Path.Combine(webHostEnvironment.WebRootPath, relativePath); // Dosya dizinini al

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string fullPath = Path.Combine(directoryPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fullPath;
        }

        public static bool IsImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;


            if (!file.ContentType.StartsWith("image/"))
                return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
                return false;


            return true;
        }

        public static void DeleteImage(string imagePath, IWebHostEnvironment webHostEnvironment)
        {
            string fullPath = Path.Combine(webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));

            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);
            
        }
    }
}

namespace Wolt.API.Things
{
    public static class FileService
    {

        public static string SaveImage(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string fileName = Guid.NewGuid() + "-" + file.FileName;
            string relativePath = "images"; 
            string fullPath = Path.Combine(webHostEnvironment.WebRootPath, relativePath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
                
            return Path.Combine("/", relativePath, fileName).Replace("\\", "/");
        }
    }
}

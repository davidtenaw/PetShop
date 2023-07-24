namespace PetShop.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment host;

        public FileService(IWebHostEnvironment host)
        {
            this.host = host;   
            
        }

        public string SaveFile(IFormFile file)
        {
            var rootPath = host.WebRootPath;
            var filePath = Path.Combine(rootPath, "Images", file.FileName);
            if (!File.Exists(filePath))
            {
                using var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
            }
            return file.FileName;
        }
    }
}

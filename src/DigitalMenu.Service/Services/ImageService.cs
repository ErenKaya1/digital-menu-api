using System.IO;
using System.Threading.Tasks;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Service.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _wwwRootPath;

        public ImageService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _wwwRootPath = _hostEnvironment.WebRootPath;
        }

        public async Task SaveCompanyLogoAsync(IFormFile file, bool replace)
        {
            if (!IsImage(file)) return;
            var imagePath = Path.Combine(_wwwRootPath, "logo", file.FileName);

            if (replace)
                File.Delete(imagePath);

            using (var stream = new FileStream(imagePath, FileMode.Create))
                await file.CopyToAsync(stream);
        }

        private bool IsImage(IFormFile file)
        {
            switch (Path.GetExtension(file.FileName).ToLower())
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".jfif":
                case ".gif":
                case ".tiff":
                case ".pjp":
                case ".svg":
                case ".bmp":
                case ".webp":
                case ".ico":
                case ".tif":
                case ".avif":
                    return true;
                default:
                    return false;
            }
        }
    }
}
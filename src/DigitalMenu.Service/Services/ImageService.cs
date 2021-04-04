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

        public async Task<bool> SaveCompanyLogoAsync(IFormFile file, bool replace)
        {
            if (!IsImage(file)) return false;
            var imagePath = Path.Combine(_wwwRootPath, "logo", file.FileName);

            if (replace)
                File.Delete(imagePath);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Close();
            }

            return true;
        }

        public async Task<bool> SaveCategoryImageAsync(IFormFile file, System.Guid userId)
        {
            if (!IsImage(file)) return false;
            var imagesPath = Path.Combine(_wwwRootPath, userId.ToString(), "category");
            if (!Directory.Exists(imagesPath))
                Directory.CreateDirectory(imagesPath);

            var imagePath = Path.Combine(imagesPath, file.FileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Close();
            }

            return true;
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
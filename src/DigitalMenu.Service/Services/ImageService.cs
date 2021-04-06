using System;
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

        public async Task<bool> SaveCategoryImageAsync(IFormFile file, Guid userId)
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

        public async Task<bool> ReplaceCategoryImageAsync(IFormFile newFile, Guid userId, string oldFileName)
        {
            if (!IsImage(newFile)) return false;
            var imagesPath = Path.Combine(_wwwRootPath, userId.ToString(), "category");
            if (!Directory.Exists(imagesPath))
                Directory.CreateDirectory(imagesPath);

            if (!string.IsNullOrEmpty(oldFileName))
            {
                var oldImagePath = Path.Combine(imagesPath, oldFileName);
                if (File.Exists(oldImagePath))
                    File.Delete(oldImagePath);
            }

            var newImagePath = Path.Combine(imagesPath, newFile.FileName);
            using (var stream = new FileStream(newImagePath, FileMode.Create))
            {
                await newFile.CopyToAsync(stream);
                stream.Close();
            }

            return true;
        }

        public void DeleteCategoryImageAsync(Guid userId, string imageName)
        {
            var imagePath = Path.Combine(_wwwRootPath, userId.ToString(), "category", imageName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
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

        public async Task<bool> SaveProductImageAsync(IFormFile file)
        {
            if (!IsImage(file)) return false;
            var imagesPath = Path.Combine(_wwwRootPath, "product");
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
    }
}
using System;
using System.IO;
using System.Threading.Tasks;
using DigitalMenu.Common.Extensions;
using DigitalMenu.Service.Contracts;
using DigitalMenu.Service.Services.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Service.Services
{
    public class ImageService : BaseService, IImageService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _wwwRootPath;

        public ImageService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _wwwRootPath = _hostEnvironment.WebRootPath;
        }

        public async Task<bool> SaveCompanyLogoAsync(IFormFile file, Guid userId, bool replace)
        {
            if (!file.IsImage()) return false;

            var directoryPath = Path.Combine(_wwwRootPath, userId.ToString(), "logo");
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var imagePath = Path.Combine(directoryPath, file.FileName);
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
            if (!file.IsImage()) return false;
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
            if (!newFile.IsImage()) return false;
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

        public void DeleteCategoryImage(Guid userId, string imageName)
        {
            var imagePath = Path.Combine(_wwwRootPath, userId.ToString(), "category", imageName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
        }

        public async Task<bool> SaveProductImageAsync(IFormFile file, Guid userId)
        {
            if (!file.IsImage()) return false;
            var imagesPath = Path.Combine(_wwwRootPath, userId.ToString(), "product");
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

        public async Task<bool> ReplaceProductImageAsync(IFormFile newFile, Guid userId, string oldFileName)
        {
            if (!newFile.IsImage()) return false;
            var imagesPath = Path.Combine(_wwwRootPath, userId.ToString(), "product");
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

        public void DeleteProductImage(Guid userId, string imageName)
        {
            var imagePath = Path.Combine(_wwwRootPath, userId.ToString(), "product", imageName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
        }
    }
}
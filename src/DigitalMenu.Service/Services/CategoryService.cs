using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Category;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly List<Culture> _cultures;
        private readonly IImageService _imageService;

        public CategoryService(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _cultures = _unitOfWork.CultureRepository.FindAll().ToList();
            _imageService = imageService;
        }

        public async Task<ServiceResponse<object>> InsertCategoryAsync(NewCategoryModel model, Guid userId)
        {
            if (model == null) return new ServiceResponse<object>(false);
            var entityId = Guid.NewGuid();
            var entity = new Category
            {
                Id = entityId,
                UserId = userId,
            };

            var translations = new List<CategoryTranslation>
            {
                new CategoryTranslation { Id = Guid.NewGuid(), CategoryId = entityId, Name = model.NameTR, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "tr").Id },
                new CategoryTranslation { Id = Guid.NewGuid(), CategoryId = entityId, Name = string.IsNullOrEmpty(model.NameEN) ? string.Empty: model.NameEN, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "en").Id }
            };

            if (model.ImageFile != null)
                if (await _imageService.SaveCategoryImageAsync(model.ImageFile, userId))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.CategoryRepository.Add(entity);
            _unitOfWork.CategoryTranslationRepository.AddRange(translations);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }

        public async Task<ServiceResponse<List<CategoryDTO>>> GetCategoriesAsync(Guid userId)
        {
            var entities = await _unitOfWork.CategoryRepository
                            .Find(x => x.UserId == userId)
                            .Include(x => x.CategoryTranslation)
                            .Select(x => new CategoryDTO
                            {
                                Id = x.Id,
                                NameTR = x.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Name,
                                NameEN = x.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en") == null
                                         ? x.CategoryTranslation.FirstOrDefault(x => x.Culture.IsDefaultCulture).Name
                                         : x.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Name,
                                ImagePath = x.HasImage ? $"https://localhost:5001/{userId}/category/{x.ImageName}" : string.Empty
                            })
                            .ToListAsync();

            return new ServiceResponse<List<CategoryDTO>>(true) { Data = entities };
        }

        public async Task<ServiceResponse<object>> UpdateCategoryAsync(UpdateCategoryModel model, Guid userId)
        {
            var entity = await _unitOfWork.CategoryRepository.Find(x => x.Id == model.Id && x.UserId == userId).Include(x => x.CategoryTranslation).FirstOrDefaultAsync();
            if (entity == null) return new ServiceResponse<object>(false, "category not found");

            entity.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Name = model.NameTR;
            entity.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Name = string.IsNullOrEmpty(model.NameEN) ? string.Empty : model.NameEN;

            if (model.ImageFile != null)
                if (await _imageService.ReplaceCategoryImageAsync(model.ImageFile, userId, entity.ImageName))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.CategoryRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }

        public async Task<ServiceResponse<object>> DeleteCategoryAsync(Guid categoryId, Guid userId)
        {
            var entity = await _unitOfWork.CategoryRepository.FindOneAsync(x => x.Id == categoryId && x.UserId == userId);
            if(entity == null) return new ServiceResponse<object>(false);
            if (entity.HasImage)
                _imageService.DeleteCategoryImage(userId, entity.ImageName);

            _unitOfWork.CategoryRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }
    }
}
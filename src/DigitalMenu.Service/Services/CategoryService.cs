using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Category;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

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
                new CategoryTranslation { Id = Guid.NewGuid(), CategoryId = entityId, Name = model.NameEN, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "en").Id }
            };

            if (model.ImageFile != null)
                if (await _imageService.SaveCategoryImageAsync(model.ImageFile, userId))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.CategoryRepository.Add(entity);
            _unitOfWork.CategoryTranslationRepository.AddRange(translations);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }
    }
}
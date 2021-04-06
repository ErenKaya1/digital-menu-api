using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Product;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly List<Culture> _cultures;
        private readonly IImageService _imageService;

        public ProductService(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _cultures = _unitOfWork.CultureRepository.FindAll().ToList();
            _imageService = imageService;
        }

        public async Task<ServiceResponse<object>> InsertProductAsync(Guid userId, NewProductModel model)
        {
            if (model == null) return new ServiceResponse<object>(false);
            var entityId = Guid.NewGuid();
            var entity = new Product
            {
                Id = entityId,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            var translations = new List<ProductTranslation>
            {
                new ProductTranslation { Id = Guid.NewGuid(), ProductId = entityId, Name = model.NameTR, Description = model.DescriptionTR, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "tr").Id },
                new ProductTranslation { Id = Guid.NewGuid(), ProductId = entityId, Name = string.IsNullOrEmpty(model.NameEN) ? string.Empty : model.NameEN, Description = string.IsNullOrEmpty(model.DescriptionEN) ? string.Empty : model.DescriptionEN, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "tr").Id }
            };

            if (model.ImageFile != null)
                if (await _imageService.SaveProductImageAsync(model.ImageFile))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.ProductRepository.Add(entity);
            _unitOfWork.ProductTranslationRepository.AddRange(translations);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }
    }
}
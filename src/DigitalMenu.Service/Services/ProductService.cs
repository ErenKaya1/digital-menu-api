using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Common.Enum;
using DigitalMenu.Core.Model.Product;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;

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
            var subscriptionStatus = await CheckSubscriptionAsync(userId);
            if (subscriptionStatus != SubscriptionCheckResult.Success)
                return new ServiceResponse<object>(false, ((int)subscriptionStatus).ToString());

            var menu = await _unitOfWork.MenuRepository.FindOneAsync(x => x.UserId == userId);
            if (menu == null)
            {
                menu = new Menu
                {
                    Id = Guid.NewGuid(),
                    UserId = userId
                };

                _unitOfWork.MenuRepository.Add(menu);
            }

            var entityId = Guid.NewGuid();
            var entity = new Product
            {
                Id = entityId,
                Price = model.Price,
                CategoryId = model.CategoryId,
                MenuId = menu.Id
            };

            var translations = new List<ProductTranslation>
            {
                new ProductTranslation { Id = Guid.NewGuid(), ProductId = entityId, Name = model.NameTR, Description = string.IsNullOrEmpty(model.DescriptionTR) ? string.Empty : model.DescriptionTR, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "tr").Id },
                new ProductTranslation { Id = Guid.NewGuid(), ProductId = entityId, Name = string.IsNullOrEmpty(model.NameEN) ? string.Empty : model.NameEN, Description = string.IsNullOrEmpty(model.DescriptionEN) ? string.Empty : model.DescriptionEN, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "en").Id }
            };

            if (model.ImageFile != null)
                if (await _imageService.SaveProductImageAsync(model.ImageFile, userId))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.ProductRepository.Add(entity);
            _unitOfWork.ProductTranslationRepository.AddRange(translations);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetProductsAsync(Guid userId)
        {
            var menu = await _unitOfWork.MenuRepository
                        .Find(x => x.UserId == userId)
                        .Include(x => x.Product)
                        .ThenInclude(x => x.ProductTranslation)
                        .ThenInclude(x => x.Culture)
                        .FirstOrDefaultAsync();

            if (menu == null) return new ServiceResponse<List<ProductDTO>>(false) { Data = new List<ProductDTO>() };
            if (menu.Product == null) return new ServiceResponse<List<ProductDTO>>(false) { Data = new List<ProductDTO>() };

            var entities = menu.Product.Select(x => new ProductDTO
            {
                Id = x.Id,
                Price = x.Price,
                NameTR = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Name,
                NameEN = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en") == null
                         ? x.ProductTranslation.FirstOrDefault(x => x.Culture.IsDefaultCulture).Name
                         : x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Name,
                DescriptionTR = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Description,
                DescriptionEN = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en") == null
                                ? x.ProductTranslation.FirstOrDefault(x => x.Culture.IsDefaultCulture).Description
                                : x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Description,
                CategoryId = x.CategoryId,
                ImagePath = x.HasImage ? $"https://localhost:5001/{menu.UserId}/product/{x.ImageName}" : string.Empty
            }).ToList();

            return new ServiceResponse<List<ProductDTO>>(true) { Data = entities };
        }

        public async Task<ServiceResponse<object>> UpdateProductAsync(Guid userId, UpdateProductModel model)
        {
            if (model == null) return new ServiceResponse<object>(false, "model was null");
            var menu = await _unitOfWork.MenuRepository.FindOneAsync(x => x.UserId == userId);
            if (menu == null) return new ServiceResponse<object>(false, "menu not found");
            var entity = await _unitOfWork.ProductRepository
                        .Find(x => x.MenuId == menu.Id && x.Id == model.Id)
                        .Include(x => x.ProductTranslation)
                        .ThenInclude(x => x.Culture)
                        .FirstOrDefaultAsync();
            if (entity == null) return new ServiceResponse<object>(false, "product not found");

            entity.Price = model.Price;
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Name = model.NameTR;
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Description = string.IsNullOrEmpty(model.DescriptionTR) ? string.Empty : model.DescriptionTR;
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Name = string.IsNullOrEmpty(model.NameEN) ? string.Empty : model.NameEN;
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Description = string.IsNullOrEmpty(model.DescriptionEN) ? string.Empty : model.DescriptionEN;

            if (model.ImageFile != null)
                if (await _imageService.ReplaceProductImageAsync(model.ImageFile, userId, entity.ImageName))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.ProductRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }

        private async Task<SubscriptionCheckResult> CheckSubscriptionAsync(Guid userId)
        {
            var subscription = await _unitOfWork.SubscriptionRepository
                            .Find(x => x.UserId == userId)
                            .Include(x => x.User)
                            .Include(x => x.SubscriptionType)
                            .ThenInclude(x => x.SubscriptionTypeFeature)
                            .FirstOrDefaultAsync();

            var menu = await _unitOfWork.MenuRepository.Find(x => x.UserId == userId).Include(x => x.Product).FirstOrDefaultAsync();

            // first product
            if (menu == null)
                return SubscriptionCheckResult.Success;

            // trial mode check
            if (subscription.IsTrialMode)
                return SubscriptionCheckResult.Success;

            // unlimited feature (premium subscription) check
            if (subscription.SubscriptionType.SubscriptionTypeFeature.FirstOrDefault(x => x.SubscriptionFeatureName == SubscriptionFeatureName.Product).IsUnlimited)
                return SubscriptionCheckResult.Success;

            // subscription status check
            if (subscription.SubscriptionStatus == SubscriptionStatus.Expired)
                return SubscriptionCheckResult.Expired;

            // subscription status check
            if (subscription.SubscriptionStatus == SubscriptionStatus.Suspended)
                return SubscriptionCheckResult.Suspended;

            // remained value check
            if (menu.ProductCount >= subscription.SubscriptionType.SubscriptionTypeFeature.FirstOrDefault(x => x.SubscriptionFeatureName == SubscriptionFeatureName.Product).TotalValue)
                return SubscriptionCheckResult.MaxValue;

            return SubscriptionCheckResult.Success;
        }

        public async Task<ServiceResponse<object>> DeleteProductAsync(Guid userId, Guid productId)
        {
            var menu = await _unitOfWork.MenuRepository.FindOneAsync(x => x.UserId == userId);
            if (menu == null) return new ServiceResponse<object>(false, "menu not found");
            var entity = await _unitOfWork.ProductRepository.FindOneAsync(x => x.Id == productId && x.Menu.UserId == userId);
            if (entity == null) return new ServiceResponse<object>(false, "product not found");

            if (entity.HasImage)
                _imageService.DeleteProductImage(userId, entity.ImageName);
            _unitOfWork.ProductRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }
    }
}
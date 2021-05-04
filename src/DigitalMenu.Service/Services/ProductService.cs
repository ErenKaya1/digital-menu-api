using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Common.Enum;
using DigitalMenu.Core.Cache;
using DigitalMenu.Core.Constants;
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
        private readonly IRedisCacheService _redisCacheService;

        public ProductService(IUnitOfWork unitOfWork, IImageService imageService, IRedisCacheService redisCacheService)
        {
            _unitOfWork = unitOfWork;
            _cultures = _unitOfWork.CultureRepository.FindAll().ToList();
            _imageService = imageService;
            _redisCacheService = redisCacheService;
        }

        public async Task<ServiceResponse<object>> InsertProductAsync(Guid userId, NewProductModel model)
        {
            if (model == null) return new ServiceResponse<object>(false);
            var subscriptionStatus = await CheckSubscriptionAsync(userId);
            if (subscriptionStatus != SubscriptionCheckResult.Success)
                return new ServiceResponse<object>(false, ((int)subscriptionStatus).ToString());

            var user = await _unitOfWork.UserRepository.Find(x => x.Id == userId).Include(x => x.Company).FirstOrDefaultAsync();
            var menu = await _unitOfWork.MenuRepository.FindOneAsync(x => x.UserId == userId);
            if (menu == null)
            {
                menu = new Menu
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    BackgroundColor = DefaultMenuTheme.BackgroundColor,
                    TextColor = DefaultMenuTheme.TextColor,
                    PriceColor = DefaultMenuTheme.PriceColor,
                    CategoryDescriptionColor = DefaultMenuTheme.CategoryDescriptionColor,
                    SelectedCategoryBorderColor = DefaultMenuTheme.SelectedCategoryBorderColor,
                    ProductBackgroundColor = DefaultMenuTheme.ProductBackgroundColor,
                    LanguageCurrencyBackgroundColor = DefaultMenuTheme.LanguageCurrencyBackgroundColor,
                    LanguageCurrencyTextColor = DefaultMenuTheme.LanguageCurrencyTextColor,
                    LinkColor = DefaultMenuTheme.LinkColor,
                };

                if (user.Company != null)
                    menu.CompanyId = user.CompanyId;

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
                new ProductTranslation { Id = Guid.NewGuid(), ProductId = entityId, Name = model.NameTR, Description = model.DescriptionTR, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "tr").Id },
                new ProductTranslation { Id = Guid.NewGuid(), ProductId = entityId, Name = model.NameEN, Description = model.DescriptionEN, CultureId = _cultures.FirstOrDefault(x => x.CultureCode == "en").Id }
            };

            if (model.ImageFile != null)
                if (await _imageService.SaveProductImageAsync(model.ImageFile, userId))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.ProductRepository.Add(entity);
            _unitOfWork.ProductTranslationRepository.AddRange(translations);
            await _unitOfWork.SaveChangesAsync();

            // clear cache
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_tr");
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_en");

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
                NameEN = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Name,
                DescriptionTR = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Description,
                DescriptionEN = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Description,
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
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "tr").Description = model.DescriptionTR;
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Name = model.NameEN;
            entity.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == "en").Description = model.DescriptionEN;

            if (model.ImageFile != null)
                if (await _imageService.ReplaceProductImageAsync(model.ImageFile, userId, entity.ImageName))
                    entity.ImageName = model.ImageFile.FileName;

            _unitOfWork.ProductRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            // clear cache
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_tr");
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_en");

            return new ServiceResponse<object>(true);
        }

        private async Task<SubscriptionCheckResult> CheckSubscriptionAsync(Guid userId)
        {
            var subscription = await _unitOfWork.SubscriptionRepository
                            .Find(x => x.UserId == userId && x.IsCurrent)
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
            if (subscription.IsExpired)
                return SubscriptionCheckResult.Expired;

            // subscription status check
            if (subscription.IsSuspended)
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

            // clear cache
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_tr");
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_en");

            return new ServiceResponse<object>(true);
        }
    }
}
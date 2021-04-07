using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Common.Enum;
using DigitalMenu.Core.Model.Product;
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

            // subscription status check / active => true / expired, suspended => false
            if (subscription.SubscriptionStatus == SubscriptionStatus.Expired)
                return SubscriptionCheckResult.Expired;

            if (subscription.SubscriptionStatus == SubscriptionStatus.Suspended)
                return SubscriptionCheckResult.Suspended;

            // remained value check
            System.Console.WriteLine(menu.ProductCount);
            if (menu.ProductCount >= subscription.SubscriptionType.SubscriptionTypeFeature.FirstOrDefault(x => x.SubscriptionFeatureName == SubscriptionFeatureName.Product).TotalValue)
                return SubscriptionCheckResult.MaxValue;

            return SubscriptionCheckResult.Success;
        }
    }
}
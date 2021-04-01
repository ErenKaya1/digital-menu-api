using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Core.Cache;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Service.Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRedisCacheService _redisCacheService;

        public SubscriptionTypeService(IUnitOfWork unitOfWork, IRedisCacheService redisCacheService)
        {
            _unitOfWork = unitOfWork;
            _redisCacheService = redisCacheService;
        }

        public async Task<ServiceResponse<List<SubscriptionTypeDTO>>> GetSubscriptionTypesAsync(string cultureCode)
        {
            var entities = new List<SubscriptionTypeDTO>();

            // SubscriptionTypes_tr, SubscriptionTypes_en
            if (_redisCacheService.IsSet("SubscriptionTypes_" + cultureCode))
            {
                entities = _redisCacheService.Get<List<SubscriptionTypeDTO>>("SubscriptionTypes_" + cultureCode);
            }
            else
            {
                entities = await _unitOfWork.SubscriptionTypeRepository
                                    .FindAll()
                                    .OrderBy(x => x.Price)
                                    .Include(x => x.SubscriptionTypeTranslation)
                                    .Include(x => x.SubscriptionTypeFeature.OrderByDescending(x => x.TotalValue))
                                    .ThenInclude(x => x.SubscriptionTypeFeatureTranslation)
                                    .Select(x => new SubscriptionTypeDTO
                                    {
                                        Id = x.Id,
                                        Title = x.SubscriptionTypeTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode) == null 
                                                ? x.SubscriptionTypeTranslation.First(x => x.Culture.IsDefaultCulture).Title 
                                                : x.SubscriptionTypeTranslation.First(x => x.Culture.CultureCode == cultureCode).Title,
                                        Price = x.Price,
                                        Features = x.SubscriptionTypeFeature.Select(x => new SubscriptionTypeFeatureDTO
                                        {
                                            IsUnlimited = x.IsUnlimited,
                                            TotalValue = Convert.ToInt32(x.TotalValue),
                                            Name = x.SubscriptionTypeFeatureTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode) == null
                                                ? x.SubscriptionTypeFeatureTranslation.First(x => x.Culture.IsDefaultCulture).Name
                                                : x.SubscriptionTypeFeatureTranslation.First(x => x.Culture.CultureCode == cultureCode).Name

                                        }).ToList()
                                    })
                                    .ToListAsync();

                _redisCacheService.Set("SubscriptionTypes_" + cultureCode, entities);
            }

            return new ServiceResponse<List<SubscriptionTypeDTO>>(true) { Data = entities };
        }
    }
}
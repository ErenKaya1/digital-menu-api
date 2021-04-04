using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly DMContext _dbContext;
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public SubscriptionController(DMContext dbContext, ISubscriptionTypeService subscriptionTypeService)
        {
            _dbContext = dbContext;
            _subscriptionTypeService = subscriptionTypeService;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetSubscriptionTypes()
        {
            var response = await _subscriptionTypeService.GetSubscriptionTypesAsync(GetCurrentLanguage());
            return Success(data: response.Data);
        }

        [HttpGet("seed")]
        public IActionResult SeedData()
        {
            var starterSubscriptionTypeFeatures = new List<SubscriptionTypeFeature>
            {
                new SubscriptionTypeFeature
                {
                    Id = Guid.Parse("41cdda69-aa5f-496f-8c1a-3f26d1a32dae"),
                    TotalValue = 20,
                    IsUnlimited = false,
                    SubscriptionTypeFeatureTranslation = new List<SubscriptionTypeFeatureTranslation>
                    {
                        new SubscriptionTypeFeatureTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "tr").Id,
                            Name = "Ürün",
                            SubscriptionTypeFeatureId = Guid.Parse("41cdda69-aa5f-496f-8c1a-3f26d1a32dae")
                        },
                        new SubscriptionTypeFeatureTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "en").Id,
                            Name = "Product",
                            SubscriptionTypeFeatureId = Guid.Parse("41cdda69-aa5f-496f-8c1a-3f26d1a32dae")
                        }
                    }
                },
            };

            var ecoSubscriptionTypeFeatures = new List<SubscriptionTypeFeature>
            {
                new SubscriptionTypeFeature
                {
                    Id = Guid.Parse("9abf06ab-0c1a-4c63-a141-e512fe306c1e"),
                    TotalValue = 40,
                    IsUnlimited = false,
                    SubscriptionTypeFeatureTranslation = new List<SubscriptionTypeFeatureTranslation>
                    {
                        new SubscriptionTypeFeatureTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "tr").Id,
                            Name = "Ürün",
                            SubscriptionTypeFeatureId = Guid.Parse("9abf06ab-0c1a-4c63-a141-e512fe306c1e")
                        },
                        new SubscriptionTypeFeatureTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "en").Id,
                            Name = "Product",
                            SubscriptionTypeFeatureId = Guid.Parse("9abf06ab-0c1a-4c63-a141-e512fe306c1e")
                        }
                    }
                },
            };

            var premiumSubscriptionTypeFeatures = new List<SubscriptionTypeFeature>
            {
                new SubscriptionTypeFeature
                {
                    Id = Guid.Parse("da12028f-418a-4bd2-9617-27c4aec8372c"),
                    IsUnlimited = true,
                    SubscriptionTypeFeatureTranslation = new List<SubscriptionTypeFeatureTranslation>
                    {
                        new SubscriptionTypeFeatureTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "tr").Id,
                            Name = "Ürün",
                            SubscriptionTypeFeatureId = Guid.Parse("da12028f-418a-4bd2-9617-27c4aec8372c")
                        },
                        new SubscriptionTypeFeatureTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "en").Id,
                            Name = "Product",
                            SubscriptionTypeFeatureId = Guid.Parse("da12028f-418a-4bd2-9617-27c4aec8372c")
                        }
                    }
                },
            };

            var subscriptionTypes = new List<SubscriptionType>
            {
                new SubscriptionType
                {
                    Id = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                    Price = 5,
                    SubscriptionTypeFeature = starterSubscriptionTypeFeatures,
                    SubscriptionTypeTranslation = new List<SubscriptionTypeTranslation>
                    {
                        new SubscriptionTypeTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "tr").Id,
                            Title = "Giriş",
                            SubscriptionTypeId = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                        },
                        new SubscriptionTypeTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "en").Id,
                            Title = "Starter",
                            SubscriptionTypeId = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                        },
                    }
                },
                new SubscriptionType
                {
                    Id = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                    Price = 10,
                    SubscriptionTypeFeature = ecoSubscriptionTypeFeatures,
                    SubscriptionTypeTranslation = new List<SubscriptionTypeTranslation>
                    {
                        new SubscriptionTypeTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "tr").Id,
                            Title = "Ekonomik",
                            SubscriptionTypeId = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                        },
                        new SubscriptionTypeTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "en").Id,
                            Title = "Economic",
                            SubscriptionTypeId = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                        },
                    }
                },
                new SubscriptionType
                {
                    Id = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                    Price = 20,
                    SubscriptionTypeFeature = premiumSubscriptionTypeFeatures,
                    SubscriptionTypeTranslation = new List<SubscriptionTypeTranslation>
                    {
                        new SubscriptionTypeTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "tr").Id,
                            Title = "Premium",
                            SubscriptionTypeId = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                        },
                        new SubscriptionTypeTranslation
                        {
                            Id = Guid.NewGuid(),
                            CultureId = _dbContext.Culture.FirstOrDefault(x => x.CultureCode == "en").Id,
                            Title = "Premium",
                            SubscriptionTypeId = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                        },
                    }
                },
            };

            _dbContext.SubscriptionType.AddRange(subscriptionTypes);
            _dbContext.SaveChanges();

            return Success();
        }
    }
}
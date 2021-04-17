using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Core.Cache;
using DigitalMenu.Core.Constants;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRedisCacheService _redisCacheService;

        public MenuService(IUnitOfWork unitOfWork, IRedisCacheService redisCacheService)
        {
            _unitOfWork = unitOfWork;
            _redisCacheService = redisCacheService;
        }

        public async Task<ServiceResponse<MenuDTO>> GetMenuByCompanySlugAsync(string companySlug, string cultureCode)
        {
            var menu = await _unitOfWork.MenuRepository
                        .Find(x => x.Company.Slug == companySlug)
                        .Include(x => x.Company)
                        .FirstOrDefaultAsync();

            var dto = new MenuDTO();
            var redisKey = RedisKeyPrefixes.MENU + menu.UserId.ToString() + "_" + cultureCode;

            // menu_userId_tr, menu_userId_en
            if (_redisCacheService.IsSet(redisKey))
            {
                dto = _redisCacheService.Get<MenuDTO>(redisKey);
            }
            else
            {
                var categories = await _unitOfWork.CategoryRepository
                                        .Find(x => x.UserId == menu.UserId)
                                        .Include(x => x.CategoryTranslation)
                                        .ThenInclude(x => x.Culture)
                                        .Include(x => x.Product)
                                        .ThenInclude(x => x.ProductTranslation)
                                        .ThenInclude(x => x.Culture)
                                        .ToListAsync();

                dto = new MenuDTO
                {
                    CompanyLogo = menu.Company.LogoName,
                    CompanyName = menu.Company.Name,
                    Categories = categories.Select(x => new CategoryDTO
                    {
                        Id = x.Id,
                        Name = x.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode) == null
                               ? x.CategoryTranslation.FirstOrDefault(x => x.Culture.IsDefaultCulture).Name
                               : x.CategoryTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode).Name,
                        ImagePath = x.HasImage ? $"https://localhost:5001/{menu.UserId}/category/{x.ImageName}" : string.Empty,
                        Products = x.Product.Select(x => new ProductDTO
                        {
                            Id = x.Id,
                            Name = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode) == null
                                   ? x.ProductTranslation.FirstOrDefault(x => x.Culture.IsDefaultCulture).Name
                                   : x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode).Name,
                            Description = x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode) == null
                                          ? x.ProductTranslation.FirstOrDefault(x => x.Culture.IsDefaultCulture).Description
                                          : x.ProductTranslation.FirstOrDefault(x => x.Culture.CultureCode == cultureCode).Description,
                            Price = x.Price,
                            ImagePath = x.HasImage ? $"https://localhost:5001/{menu.UserId}/product/{x.ImageName}" : string.Empty,
                            CategoryId = x.CategoryId
                        }).ToList()
                    }).ToList()
                };

                _redisCacheService.Set(redisKey, dto);
            }

            return new ServiceResponse<MenuDTO>(true) { Data = dto };
        }
    }
}
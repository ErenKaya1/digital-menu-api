using System;
using System.Threading.Tasks;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<QrCodeDTO>> GetQrCodeParameters(Guid userId)
        {
            var menu = await _unitOfWork.MenuRepository.FindOneAsync(x => x.UserId == userId);
            if (menu == null) return new ServiceResponse<QrCodeDTO>(false, "menu not found");

            var dto = new QrCodeDTO
            {
                Color = menu.QrCodeColor,
                BackgroundColor = menu.QrCodeBackgroundColor,
                Scale = menu.QrCodeScale,
                Margin = menu.QrCodeMargin
            };

            return new ServiceResponse<QrCodeDTO>(true) { Data = dto };
        }
    }
}
using System;
using System.Threading.Tasks;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface IMenuService
    {
        Task<ServiceResponse<QrCodeDTO>> GetQrCodeParameters(Guid userId);
    }
}
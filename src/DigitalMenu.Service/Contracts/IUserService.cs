using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;

namespace DigitalMenu.Service.Contracts
{
    public interface IUserService
    {
        ServiceResponse<DMUser> InsertUser(UserDTO dto);
    }
}
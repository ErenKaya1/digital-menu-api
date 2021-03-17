using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("newuser")]
        public async Task<IActionResult> Get()
        {
            var serviceResponse = await _userService.InsertUserAsync(new UserDTO
            {
                UserName = "erenkaya123",
                FirstName = "eren",
                LastName = "kaya",
                EmailAddress = "eerenkaya@yahoo.com",
                PhoneNumber = "05396046268",
                Password = "erenkaya8582"
            });

            if (serviceResponse.Success)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginModel model)
        {
            var response = await _userService.AuthenticateAsync(model);

            if (response.Success)
            {
                return Ok(new
                {
                    token = response.Data.AccessToken,
                    refreshToken = response.Data.RefreshToken
                });
            }

            return BadRequest();
        }
    }
}
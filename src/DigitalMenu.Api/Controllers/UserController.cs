using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var response = await _userService.InsertUserAsync(model, GetClientIpAddress());
            if (!response.Success) return Error(response.Message, response.InternalMessage);
            SetTokenCookie(response.Data.RefreshToken, false);

            var data = new
            {
                UserId = response.Data.Id,
                Token = response.Data.AccessToken
            };

            return Success(data: data);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
        {
            var response = await _userService.AuthenticateAsync(model, GetClientIpAddress());
            if (!response.Success) return Error(response.Message, response.InternalMessage, code: 401);
            SetTokenCookie(response.Data.RefreshToken, model.IsPersistent);

            var data = new
            {
                UserId = response.Data.Id,
                Token = response.Data.AccessToken,
            };

            return Success(data: data);
        }

        [HttpGet("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken, GetClientIpAddress());
            if (!response.Success) return Error(response.Message, response.InternalMessage);
            SetTokenCookie(response.Data.RefreshToken, true);

            var data = new
            {
                UserId = response.Data.Id,
                token = response.Data.AccessToken
            };

            return Success(data: data);
        }

        [HttpGet("logout/{userId}")]
        [Authorize]
        public async Task<IActionResult> Logout([FromRoute] string userId)
        {
            Response.Cookies.Delete("refreshToken");
            await _tokenService.RevokeRefreshTokensAsync(Guid.Parse(userId), GetClientIpAddress());
            return Success();
        }
    }
}
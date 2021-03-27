using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Constants;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DigitalMenu.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IDataProtector _dataProtector;
        private readonly IMailService _mailService;
        private readonly IOptions<MailSettings> _mailSettings;

        public UserController(IUserService userService, ITokenService tokenService, IDataProtectionProvider dataProtectionProvider, IMailService mailService, IOptions<MailSettings> mailSettings)
        {
            _userService = userService;
            _tokenService = tokenService;
            _dataProtector = dataProtectionProvider.CreateProtector(DataProtectionKeys.ResetPasswordTokenKey);
            _mailService = mailService;
            _mailSettings = mailSettings;
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

        [HttpDelete("logout/{userId}")]
        public async Task<IActionResult> Logout([FromRoute] string userId)
        {
            Response.Cookies.Delete("refreshToken");
            await _tokenService.RevokeRefreshTokensAsync(Guid.Parse(userId), GetClientIpAddress());
            return Success();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var response = await _userService.SendResetPasswordMailAsync(model.EmailAddress);
            if (!response.Success)
                return Error(response.Message, response.InternalMessage);

            return Success(response.Message, response.InternalMessage);
        }

        [HttpPut("reset-password/{userId}/{token}")]
        public async Task<IActionResult> ResetPassword([FromRoute] string userId, [FromRoute] string token, [FromBody] ResetPasswordModel model)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token)) return Error("token and userid required for reset password");
            if (Guid.TryParse(userId, out Guid id))
            {
                var decodedToken = HttpUtility.UrlDecode(token);
                var unprotectedToken = _dataProtector.Unprotect(decodedToken);
                var result = await _userService.ResetPasswordAsync(id, model.Password, unprotectedToken);
                if (!result.Success) return Error(result.Message, result.InternalMessage);
                return Success(result.Message);
            }

            return Error("invalid user id", "user id must be in guid format");
        }
    }
}
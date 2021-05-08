using System;
using System.Threading.Tasks;
using System.Web;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Common.Helper;
using DigitalMenu.Core.Constants;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
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
            var response = await _userService.InsertUserAsync(model, HttpHelper.GetClientIpAddress(HttpContext));
            if (!response.Success) return Error(response.Message, response.InternalMessage, code: 409, errorCode: response.ErrorCode);
            HttpHelper.SetRefreshTokenCookie(HttpContext, response.Data.RefreshToken, false);

            var data = new
            {
                Token = response.Data.AccessToken,
                User = new
                {
                    UserId = response.Data.Id,
                    Username = response.Data.UserName,
                    FirstName = response.Data.FirstName,
                    LastName = response.Data.LastName,
                    EmailAddress = response.Data.EmailAddress,
                    PhoneNumber = response.Data.PhoneNumber,
                }
            };

            return Success(data: data);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
        {
            var response = await _userService.AuthenticateAsync(model, HttpHelper.GetClientIpAddress(HttpContext));
            if (!response.Success) return Error(response.Message, response.InternalMessage, code: 401);
            HttpHelper.SetRefreshTokenCookie(HttpContext, response.Data.RefreshToken, model.IsPersistent);

            var data = new
            {
                Token = response.Data.AccessToken,
                User = new
                {
                    UserId = response.Data.Id,
                    Username = response.Data.UserName,
                    FirstName = response.Data.FirstName,
                    LastName = response.Data.LastName,
                    EmailAddress = response.Data.EmailAddress,
                    PhoneNumber = response.Data.PhoneNumber,
                }
            };

            return Success(data: data);
        }

        [HttpDelete("logout/{userId}")]
        public async Task<IActionResult> Logout([FromRoute] string userId)
        {
            Response.Cookies.Delete("refreshToken");
            await _tokenService.RevokeRefreshTokensAsync(Guid.Parse(userId), HttpHelper.GetClientIpAddress(HttpContext));
            return Success();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var response = await _userService.SendResetPasswordMailAsync(model.EmailAddress);
            return Success("email sended");
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

        [HttpPut("{userId}/update")]
        [Authorize]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UpdateProfile([FromRoute] Guid userId, [FromBody] UpdateProfileModel model)
        {
            var response = await _userService.UpdateUserAsync(userId, model);
            if (response.Success)
            {
                var data = new
                {
                    token = response.Data.AccessToken,
                    User = new
                    {
                        UserId = response.Data.Id,
                        Username = response.Data.UserName,
                        FirstName = response.Data.FirstName,
                        LastName = response.Data.LastName,
                        EmailAddress = response.Data.EmailAddress,
                        PhoneNumber = response.Data.PhoneNumber,
                    }
                };

                return Success(data: data);
            }

            return Error(response.Message, response.InternalMessage);
        }

        [HttpPut("{userId}/update-password")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromRoute] Guid userId, [FromBody] UpdatePasswordModel model)
        {
            var response = await _userService.ChangePasswordAsync(userId, model);
            if (response.Success)
                return Success(message: response.Message);

            return Error(response.Message, response.InternalMessage);
        }

        [HttpGet("{userId}/company")]
        [Authorize]
        public async Task<IActionResult> GetCompany([FromRoute] Guid userId)
        {
            var response = await _userService.GetCompanyAsync(userId);
            if (response.Success)
                return Success(data: response.Data);

            return Error(response.Message, response.InternalMessage, code: 404);
        }

        [HttpPost("{userId}/company")]
        [Authorize]
        public async Task<IActionResult> UpdateCompany([FromRoute] Guid userId, [FromForm] UpdateCompanyModel model)
        {
            var response = await _userService.UpdateCompanyAsync(userId, model);
            if (response.Success)
                return Success(data: response.Data);

            return Error(response.Message, response.InternalMessage, errorCode: response.ErrorCode);
        }
    }
}
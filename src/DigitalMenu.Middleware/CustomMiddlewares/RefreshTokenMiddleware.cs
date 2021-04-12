using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using DigitalMenu.Common.Extensions;
using DigitalMenu.Common.Helper;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalMenu.Middleware.CustomMiddlewares
{
    public class RefreshTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _services;
        private IUserService _userService;

        public RefreshTokenMiddleware(RequestDelegate next, IServiceProvider services)
        {
            _next = next;
            _services = services;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var header = context.Request.Headers["Authorization"].ToString();
                var jwt = header.Split(' ')[1];
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);

                if (token.IsExpired())
                {
                    var refreshToken = context.Request.Cookies["refreshToken"];
                    if (!string.IsNullOrEmpty(refreshToken))
                    {
                        using (var scope = _services.CreateScope())
                        {
                            _userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                            var ipAddress = HttpHelper.GetClientIpAddress(context);

                            var refreshTokenResult = await _userService.RefreshTokenAsync(refreshToken, ipAddress);
                            if (refreshTokenResult.Success)
                            {
                                HttpHelper.SetRefreshTokenCookie(context, refreshTokenResult.Data.RefreshToken, true);
                                var newJwtToken = refreshTokenResult.Data.AccessToken;

                                context.Request.Headers["Authorization"] = $"Bearer {newJwtToken}";
                                context.Response.Headers["X-New-Jwt-Token"] = newJwtToken;
                            }
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
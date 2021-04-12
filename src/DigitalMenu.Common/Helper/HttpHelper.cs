using System;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Common.Helper
{
    public class HttpHelper
    {
        public static string GetClientIpAddress(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                return context.Request.Headers["X-Forwarded-For"];
            else
                return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        public static void SetRefreshTokenCookie(HttpContext context, string token, bool isPersistent)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Expires = isPersistent ? DateTime.UtcNow.AddDays(14) : null,
            };

            context.Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
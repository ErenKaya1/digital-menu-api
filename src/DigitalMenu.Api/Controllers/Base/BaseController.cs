using System;
using System.Collections.Generic;
using DigitalMenu.Core.Model.ApiReturn;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        protected string GetCurrentLanguage()
        {
            if (Request.Headers.ContainsKey("X-Language"))
                return Request.Headers["X-Language"];
            return "tr";
        }

        [NonAction]
        protected IActionResult Success(string message = default(string), object data = default(object), int code = 200)
        {
            return new JsonResult(
                new DMReturn
                {
                    Success = true,
                    Message = message,
                    Data = data,
                    Code = code
                }
            );
        }

        [NonAction]
        protected IActionResult Error(string message = default(string), string internalMessage = default(string), object data = default(object), int code = 400, List<DMReturnError> errors = null)
        {
            var response = new DMReturn
            {
                Success = false,
                Message = message,
                InternalMessage = internalMessage,
                Data = data,
                Code = code,
                Errors = errors
            };

            switch (response.Code)
            {
                case 500:
                    return StatusCode(500, response);
                case 401:
                    return Unauthorized(response);
                case 403:
                    return Forbid();
                case 404:
                    return NotFound(response);
                case 409:
                    return Conflict(response);
                default:
                    return BadRequest(response);
            }
        }
    }
}
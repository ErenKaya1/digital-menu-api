using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Common.Helper;
using DigitalMenu.Core.Model.Subscription;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    [Authorize]
    public class SubscriptionController : BaseController
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionTypeService subscriptionTypeService, ISubscriptionService subscriptionService)
        {
            _subscriptionTypeService = subscriptionTypeService;
            _subscriptionService = subscriptionService;
        }

        [HttpGet("types")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubscriptionTypes()
        {
            System.Console.WriteLine("subscription types");
            var response = await _subscriptionTypeService.GetSubscriptionTypesAsync(GetCurrentLanguage());
            if (response.Success)
                return Success(data: response.Data);
            return Error(response.Message, response.InternalMessage, errorCode: response.ErrorCode);
        }

        [HttpGet("check/{userId}")]
        public async Task<IActionResult> CheckSubscriptionStatus([FromRoute] Guid userId)
        {
            var response = await _subscriptionService.CheckSubscriptionAsync(userId);
            if (response.Success)
                return Success(data: response.Data, message: response.Message);

            return Error(response.Message, response.InternalMessage);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> RenewSubscription([FromRoute] Guid userId, [FromForm] RenewSubscriptionModel model)
        {
            var ipAddress = HttpHelper.GetClientIpAddress(HttpContext);
            var response = await _subscriptionService.RenewSubscriptionAsync(userId, model, ipAddress);
            if (response.Success)
                return Success();

            return Error(response.Message);
        }
    }
}
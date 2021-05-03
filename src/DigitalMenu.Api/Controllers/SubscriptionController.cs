using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.Subscription;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
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
        public async Task<IActionResult> GetSubscriptionTypes()
        {
            var response = await _subscriptionTypeService.GetSubscriptionTypesAsync(GetCurrentLanguage());
            return Success(data: response.Data);
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
            System.Console.WriteLine(model.CardHolder);
            System.Console.WriteLine(model.CardNumber);
            System.Console.WriteLine(model.CardMonth);
            System.Console.WriteLine(model.CardYear);
            System.Console.WriteLine(model.CardCvv);
            System.Console.WriteLine(model.SubscriptionTypeId);

            return Success();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Common.Enum;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly DMContext _dbContext;
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public SubscriptionController(DMContext dbContext, ISubscriptionTypeService subscriptionTypeService)
        {
            _dbContext = dbContext;
            _subscriptionTypeService = subscriptionTypeService;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetSubscriptionTypes()
        {
            var response = await _subscriptionTypeService.GetSubscriptionTypesAsync(GetCurrentLanguage());
            return Success(data: response.Data);
        }
    }
}
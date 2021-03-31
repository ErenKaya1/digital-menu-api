using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace src.DigitalMenu.Service.BackgroundServices
{
    public class SubscriptionReminderService : IHostedService
    {
        private IServiceProvider _services;
        private CancellationToken _cancellationToken;
        private IMapper _mapper;
        private readonly ILogger<SubscriptionReminderService> _logger;
        private readonly IUserService _userService;

        public SubscriptionReminderService(IUserService userService, IServiceProvider services, IMapper mapper, ILogger<SubscriptionReminderService> logger)
        {
            _services = services;
            _mapper = mapper;
            _userService = userService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            DoWork();
            return Task.CompletedTask;
        }

        public async void DoWork()
        {
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
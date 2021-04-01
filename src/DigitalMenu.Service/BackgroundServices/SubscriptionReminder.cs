using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DigitalMenu.Core.Constants;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.RabbitMQ;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DigitalMenu.Service.BackgroundServices
{
    public class SubscriptionReminder : IHostedService
    {
        private IServiceProvider _services;
        private CancellationToken _cancellationToken;
        private readonly ILogger<SubscriptionReminder> _logger;
        private readonly IOptions<MailSettings> _mailSettings;

        public SubscriptionReminder(IServiceProvider services, ILogger<SubscriptionReminder> logger, IOptions<MailSettings> mailSettings)
        {
            _services = services;
            _logger = logger;
            _mailSettings = mailSettings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _logger.LogInformation("Subscription reminder background service was started");
            DoWork();
            return Task.CompletedTask;
        }

        public async void DoWork()
        {
            while (true)
            {
                using (var scope = _services.CreateScope())
                {
                    var _subscriptionService = scope.ServiceProvider.GetRequiredService<ISubscriptionService>();
                    var rabbitMQService = scope.ServiceProvider.GetRequiredService<IRabbitMQService>();
                    var subscriptions = _subscriptionService.GetAllAsync();
                    var mailTo = new List<string>();

                    foreach (var subscription in subscriptions.Result.Data)
                    {
                        if (DateTime.UtcNow.AddDays(3) >= subscription.EndDate && !subscription.IsSubscriptionReminderMailSent)
                        {
                            mailTo.Add(subscription.EmailAddress);
                            await _subscriptionService.UpdateReminderMailSentStatusByIdAsync(subscription.Id);
                        }
                    }

                    if (mailTo.Count > 0)
                    {
                        var mailDTO = new MailDTO
                        {
                            From = _mailSettings.Value.Username,
                            Subject = "Digital Menu Uyelik Yenileme",
                            Content = "<p>Digital Menu uyeliginiz 3 gun icinde sona erecektir. 3 gun sonra uyeliginizi yenilemeniz gerekmektedir.</p>",
                            To = mailTo
                        };

                        rabbitMQService.Post(MessageQueueNames.EMAIL, mailDTO);
                    }

                }

                // 1 hour delay
                await Task.Delay(3600000, _cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Subscription reminder background service was stopped");
            return Task.CompletedTask;
        }
    }
}
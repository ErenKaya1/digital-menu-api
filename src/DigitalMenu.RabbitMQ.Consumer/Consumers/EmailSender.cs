using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalMenu.Core.Constants;
using DigitalMenu.Core.Model;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DigitalMenu.RabbitMQ.Consumer.Consumers
{
    public class EmailSender : BackgroundService
    {
        private IMailService _mailService;
        private IOptions<RabbitMQConfig> _rabbitMQConfig;
        private IServiceProvider _services;
        private ILogger<EmailSender> _logger;
        private IModel _channel;
        private IConnection _connection;

        public EmailSender(IServiceProvider services, IOptions<RabbitMQConfig> rabbitMQConfig, ILogger<EmailSender> logger)
        {
            _services = services;
            _rabbitMQConfig = rabbitMQConfig;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailSender background service was started");
            using (var scope = _services.CreateScope())
            {
                _mailService = scope.ServiceProvider.GetRequiredService<IMailService>();

                var factory = new ConnectionFactory
                {
                    HostName = _rabbitMQConfig.Value.Host,
                    UserName = _rabbitMQConfig.Value.Username,
                    Password = _rabbitMQConfig.Value.Password
                };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(
                    queue: MessageQueueNames.EMAIL,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var consumer = new EventingBasicConsumer(_channel);
                _channel.BasicConsume(
                    queue: MessageQueueNames.EMAIL,
                    autoAck: true,
                    consumer: consumer
                );

                consumer.Registered += (ch, ea) => _logger.LogInformation($"consumer registered to {MessageQueueNames.EMAIL} queue");
                consumer.Received += async (ch, ea) =>
                {
                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var mailDto = JsonConvert.DeserializeObject<MailDTO>(content);

                    await _mailService.SendAsync(mailDto);
                };
            }

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
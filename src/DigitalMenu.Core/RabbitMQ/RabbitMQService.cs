using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace DigitalMenu.Core.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Post(string channelName, object data)
        {
            if (string.IsNullOrEmpty(Hostname)) throw new ArgumentNullException(nameof(Hostname));
            if (string.IsNullOrEmpty(Username)) throw new ArgumentNullException(nameof(Username));
            if (string.IsNullOrEmpty(Password)) throw new ArgumentNullException(nameof(Password));

            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = this.Hostname,
                    UserName = this.Username,
                    Password = this.Password,
                };

                using (IConnection connection = factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: channelName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    string message = JsonConvert.SerializeObject(data);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: channelName,
                        basicProperties: null,
                        body: body
                    );
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
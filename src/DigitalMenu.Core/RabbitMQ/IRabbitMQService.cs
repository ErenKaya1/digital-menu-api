namespace DigitalMenu.Core.RabbitMQ
{
    public interface IRabbitMQService
    {
        bool Post(string channelName, object data);
    }
}
namespace Coords.App.Services
{
    public interface IRabbitMQService
    {
        Task<bool> SendToQueue<T>(string queueName, T request);
    }
}

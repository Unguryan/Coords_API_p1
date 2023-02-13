using Coords.App.Services;
using Coords.Domain.Options;
using MassTransit;
using Microsoft.Extensions.Options;

namespace Coords.RabbitMQ.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IBusControl _busControl;
        private readonly IOptions<RabbitMQConfiguration> _options;

        public RabbitMQService(IBusControl busControl, IOptions<RabbitMQConfiguration> options)
        {
            _busControl = busControl;
            _options = options;
        }

        public async Task<bool> SendToQueue<T>(string queueName, T request)
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri($"{_options.Value.Uri}/{queueName}?bind=true&queue={queueName}"));
            await endpoint.Send(request);

            return true;
        }
    }
}

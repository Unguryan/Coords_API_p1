using Coords.App.Services;
using Coords.Domain.Events;
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

        public async Task<bool> SendToQueue<T>(string queueName, T request) where T : class, IBaseEvent
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri($"{_options.Value.Uri}/{queueName}_Exchange?queue={queueName}"));
            await endpoint.Send(request);

            return true;
        }
    }
}

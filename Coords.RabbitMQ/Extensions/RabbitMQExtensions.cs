using Coords.Domain.Events;
using Coords.Domain.Options;
using Coords.RabbitMQ.Consumers;
using MassTransit;

namespace Coords.RabbitMQ.Extensions
{
    public static class RabbitMQExtensions
    {
        public static void AddReceiveEndpointCreatedCoord(this IRabbitMqBusFactoryConfigurator cfg,
                                                               IBusRegistrationContext context,
                                                               RabbitMQOptions rabbitSection)
        {
            cfg.ReceiveEndpoint(rabbitSection.CreatedCoordQueue, config =>
            {
                config.ConfigureConsumeTopology = false;
                config.Bind<CreatedCoordEvent>();
                config.Consumer<CreatedCoordConsumer>();
            });
        }
    }
}

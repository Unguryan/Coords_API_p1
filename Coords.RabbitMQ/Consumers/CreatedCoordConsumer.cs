using Coords.Domain.Events;
using MassTransit;
using System.Diagnostics;

namespace Coords.RabbitMQ.Consumers
{
    public class CreatedCoordConsumer : IConsumer<CreatedCoordEvent>
    {
        public async Task Consume(ConsumeContext<CreatedCoordEvent> context)
        {
            Debug.WriteLine("TEST: " + context.Message);
        }
    }
}

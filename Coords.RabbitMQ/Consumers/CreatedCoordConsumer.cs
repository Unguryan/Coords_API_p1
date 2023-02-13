using Coord.Domain.Events;
using MassTransit;
using MediatR;
using System.Diagnostics;

namespace Coords.RabbitMQ.Consumers
{
    public class CreatedCoordConsumer : IConsumer<CreatedCoordEvent>
    {
        public CreatedCoordConsumer(IMediator mediator)
        {

        }

        public async Task Consume(ConsumeContext<CreatedCoordEvent> context)
        {
            Debug.WriteLine("TEST: " + context.Message);
        }
    }
}

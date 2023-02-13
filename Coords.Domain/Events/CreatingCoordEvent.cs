using Coords.Domain.Events;

namespace Coord.Domain.Events
{
    public record CreatingCoordEvent(decimal Longitude, decimal Latitude, string Details, string PhoneNumber) : IBaseEvent;
}

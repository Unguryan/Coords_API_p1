using Coords.Domain.Events;
using Coords.Domain.Models;

namespace Coord.Domain.Events
{
    public record CreatingCoordEvent(decimal Longitude, decimal Latitude, string Details, User User) : IBaseEvent;
}

using Coords.Domain.Models;

namespace Coords.Domain.ViewModels
{
    public record CreateCoordViewModel(decimal Longitude, decimal Latitude, string Details, string UserToken);
}

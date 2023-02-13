using Coords.Domain.Models;
using Coords.Domain.ViewModels;
using MediatR;

namespace Coords.App.Commands.CreateCoord
{
    public record CreateCoordsCommand(CreateCoordViewModel Coord) : IRequest<CreateCoordsCommandResult>;
}

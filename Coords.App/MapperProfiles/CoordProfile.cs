using AutoMapper;
using Coord.Domain.Events;
using Coords.App.Commands.CreateCoord;
using Coords.Domain.ViewModels;

namespace Coords.App.MapperProfiles
{
    public class CoordProfile : Profile
    {
        public CoordProfile()
        {
            CreateMap<CreateCoordResultViewModel, CreateCoordsCommandResult>()
                .ReverseMap();
            CreateMap<CreateCoordViewModel, CreatingCoordEvent>()
                .ReverseMap();
        }
    }
}

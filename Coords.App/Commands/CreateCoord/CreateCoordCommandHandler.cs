using AutoMapper;
using Coords.App.Services;
using MediatR;

namespace Coords.App.Commands.CreateCoord
{
    public class CreateCoordsCommandHandler : IRequestHandler<CreateCoordsCommand, CreateCoordsCommandResult>
    {
        private readonly ICoordService _coordService;
        private readonly IMapper _mapper;

        public CreateCoordsCommandHandler(ICoordService coordService, IMapper mapper)
        {
            _coordService = coordService;
            _mapper = mapper;
        }

        public async Task<CreateCoordsCommandResult> Handle(CreateCoordsCommand request, CancellationToken cancellationToken)
        {
            var result = await _coordService.CreateCoord(request.Coord);

            //return new CreateCoordsCommandResult(result.IsValid, result.IsSent);
            return _mapper.Map<CreateCoordsCommandResult>(result);
        }
    }
}

using AutoMapper;
using Coord.Domain.Events;
using Coords.App.Services;
using Coords.Domain.Options;
using Coords.Domain.ViewModels;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Coords.Infrastructure.Services
{
    public class CoordService : ICoordService
    {
        private readonly IValidator<CreateCoordViewModel> _croodsValidator;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IOptions<RabbitMQOptions> _options;

        public CoordService(IValidator<CreateCoordViewModel> croodsValidator,
                            IRabbitMQService rabbitMQService,
                            IUserService userService, 
                            IMapper mapper,
                            IOptions<RabbitMQOptions> options)
        {
            _croodsValidator = croodsValidator;
            _rabbitMQService = rabbitMQService;
            _userService = userService;
            _mapper = mapper;
            _options = options;
        }

        public async Task<CreateCoordResultViewModel> CreateCoord(CreateCoordViewModel request)
        {
            var validateRes = await _croodsValidator.ValidateAsync(request);

            if (!validateRes.IsValid)
            {
                var errorsStr = string.Empty;
                validateRes.Errors.ForEach(e => errorsStr += $"{e}\n");
                return new CreateCoordResultViewModel(false, false, errorsStr);
            }

            var user = await _userService.GetUserByToken(request.UserToken);
            if (user == null)
            {
                return new CreateCoordResultViewModel(false, false, "User Token invalid.");
            }

            //GET USER INFO, Using token
            //var @event = _mapper.Map<CreatingCoordEvent>(request);
            var @event = new CreatingCoordEvent(request.Longitude, request.Latitude, request.Details, user);
            var res = await _rabbitMQService.SendToQueue(_options.Value.CreateCoordQueue, @event);

            return new CreateCoordResultViewModel(true, res);
        }
    }
}

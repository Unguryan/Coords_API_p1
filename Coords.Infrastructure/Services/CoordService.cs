using AutoMapper;
using Coord.Domain.Events;
using Coords.App.Services;
using Coords.Domain.Options;
using Coords.Domain.ViewModels;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;

namespace Coords.Infrastructure.Services
{
    public class CoordService : ICoordService
    {
        private readonly IValidator<CreateCoordViewModel> _croodsValidator;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IMapper _mapper;
        private readonly IOptions<RabbitMQOptions> _options;

        public CoordService(IValidator<CreateCoordViewModel> croodsValidator,
                            IRabbitMQService rabbitMQService,
                            IMapper mapper,
                            IOptions<RabbitMQOptions> options)
        {
            _croodsValidator = croodsValidator;
            _rabbitMQService = rabbitMQService;
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

            var @event = _mapper.Map<CreatingCoordEvent>(request);
            var res = await _rabbitMQService.SendToQueue(_options.Value.CreateCoordQueue, @event);

            return new CreateCoordResultViewModel(true, res);
        }
    }
}

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
        private readonly IOptions<RabbitMQOptions> _options;

        public CoordService(IValidator<CreateCoordViewModel> croodsValidator,
                            IRabbitMQService rabbitMQService, 
                            IOptions<RabbitMQOptions> options)
        {
            _croodsValidator = croodsValidator;
            _rabbitMQService = rabbitMQService;
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

            var res = await _rabbitMQService.SendToQueue(_options.Value.CreateCoordQueue, request);

            return new CreateCoordResultViewModel(true, res);
        }
    }
}

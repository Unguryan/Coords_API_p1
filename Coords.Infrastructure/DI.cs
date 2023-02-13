using Coords.App;
using Coords.App.Services;
using Coords.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coords.Infrastructure
{
    public static class DI
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAssembly(configuration);

            services.AddScoped<ICoordService, CoordService>();
        }
    }
}

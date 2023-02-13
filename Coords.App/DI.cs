using Coords.Domain.Options;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Coords.App
{
    public static class DI
    {
        public static void AddAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQSection = configuration.GetSection(RabbitMQOptions.SectionName);
            services.AddOptions<RabbitMQOptions>()
                    .Bind(rabbitMQSection);

            var rabbitMQConfigurationSection = configuration.GetSection(RabbitMQConfiguration.SectionName);
            services.AddOptions<RabbitMQConfiguration>()
                   .Bind(rabbitMQConfigurationSection);

            var assebmly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assebmly);
            services.AddAutoMapper(assebmly);
            services.AddValidatorsFromAssembly(assebmly);
        }
    }
}

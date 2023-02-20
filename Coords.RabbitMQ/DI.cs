using Coords.App.Services;
using Coords.Domain.Options;
using Coords.RabbitMQ.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coords.RabbitMQ
{
    public static class DI
    {
        public static void AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitCfg = configuration.GetSection(RabbitMQConfiguration.SectionName).Get<RabbitMQConfiguration>();
            var rabbitOptions = configuration.GetSection(RabbitMQOptions.SectionName).Get<RabbitMQOptions>();

            services.AddMassTransit(x =>
            {
                //x.AddConsumers(typeof(DI).Assembly);
                
                x.AddBus(prov => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitCfg.Uri), host =>
                    {
                        host.Username(rabbitCfg.Username);
                        host.Password(rabbitCfg.Password);
                    });

                    //x.UsingRabbitMq((context, configurator) =>
                    //    cfg.ConfigureEndpoints(context));

                    //cfg.AutoDelete = true;
                }));
            });

            //services.AddSingleton<IBus>(prov => prov.GetRequiredService<IBusControl>());


            services.AddScoped<IRabbitMQService, RabbitMQService>();
        }
    }
}

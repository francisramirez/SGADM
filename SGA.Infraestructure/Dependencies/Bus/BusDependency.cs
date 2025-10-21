


using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Repositories.Confguration;
using SGA.Application.Services;
using SGA.Persistence.Repositories.Configuration;

namespace SGA.Infraestructure.Dependencies.Bus
{
    public static class BusDependency
    {
        public static void AddBusDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddTransient<IBusService, BusService>();
        }
    }
}

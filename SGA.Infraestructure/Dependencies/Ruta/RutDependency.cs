

using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Repositories.Confguration;
using SGA.Application.Services;
using SGA.Persistence.Repositories.Configuration;

namespace SGA.Infraestructure.Dependencies.Ruta
{
    public static class RutDependency
    {
        public static void AddRutaDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRutaRepository, RutaRepository>();
            services.AddTransient<IRutaService, RutaService>();
        }
    }
}

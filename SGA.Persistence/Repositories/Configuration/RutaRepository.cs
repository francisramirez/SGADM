
using Microsoft.Extensions.Logging;
using SGA.Application.Dtos.Configuration.Ruta;
using SGA.Application.Repositories.Confguration;
using SGA.Domain.Base;
using SGA.Domain.Entitines.Configuration;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories.Configuration
{
    public sealed class RutaRepository : BaseRepository<Ruta>, IRutaRepository
    {
        private readonly SGAContext context;
        private readonly ILogger<RutaRepository> _logger;

        public RutaRepository(SGAContext context, 
                              ILogger<RutaRepository> logger) : base(context)
        {
            this.context = context;
            _logger = logger;
        }


    }
}

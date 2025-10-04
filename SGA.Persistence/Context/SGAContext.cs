

using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entitines.Configuration;

namespace SGA.Persistence.Context
{
    public class SGAContext : DbContext
    {
        public SGAContext(DbContextOptions<SGAContext> options) : base(options)
        {
            
        }


        #region "Entidades del módulo de configuración"
        public DbSet<Ruta> Rutas { get; set; }

        #endregion
      

    }
}

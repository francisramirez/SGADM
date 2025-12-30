

using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entitines.Configuration;

namespace SGA.Persistence.Context
{
    public class SGAContext : DbContext
    {
        public SGAContext(DbContextOptions<SGAContext> options) : base(options)
        {
            ///  base.SavedChanges += SGAContext_SavedChanges;
            // base.SaveChangesFailed += SGAContext_SaveChangesFailed;

            // base.

          
            
        }

      



        #region "Entidades del módulo de configuración"
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Bus> Buses { get; set; }
        #endregion
      

    }
}

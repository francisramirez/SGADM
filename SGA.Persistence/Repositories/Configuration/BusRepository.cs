

using SGA.Application.Repositories.Confguration;
using SGA.Domain.Base;
using SGA.Domain.Entitines.Configuration;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories.Configuration
{
    public sealed class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(SGAContext context) : base(context)
        {
            
        }
        public override Task<OperationResult> Save(Bus entity)
        {
            return base.Save(entity);
        }
    }
}

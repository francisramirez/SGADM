

using SGA.Domain.Repository;
using SGA.Domain.Entitines.Configuration;

namespace SGA.Application.Repositories
{
    public interface IAsientoRepository : IBaseRepository<Asiento>
    {
        // Add any additional methods specific to Asiento if needed

        List<Asiento> GetAsientosByBusId(int busId);
    }
}

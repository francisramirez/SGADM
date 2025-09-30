using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Bus;

namespace SGA.Application.Interfaces
{
    public interface IBusService
    {
        Task<ServiceResult> GetBuses();
        Task<ServiceResult> GetBusById(int id);
        Task<ServiceResult> CreateBus(CreateBusDto createBusDto);
        Task<ServiceResult> UpdateBus(UpdateBusDto updateBusDto);
        Task<ServiceResult> RemoveBus(RemoveBusDto removeBusDto);
    }
}

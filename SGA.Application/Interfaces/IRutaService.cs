

using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Ruta;

namespace SGA.Application.Interfaces
{
    public interface IRutaService
    {
        Task<ServiceResult> GetAllRutasAsync();
        Task<ServiceResult> GetRutaByIdAsync(int id);
        Task<ServiceResult> CreateRutaAsync(CreateRutaDto createRutaDto);
        Task<ServiceResult> UpdateRutaAsync(UpdateRutaDto updateRutaDto);
        Task<ServiceResult> DeleteRutaAsync(RemoveRutaDto removeRutaDto);
    }
}

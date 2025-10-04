
using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Ruta;
using SGA.Application.Interfaces;
using SGA.Application.Repositories.Confguration;
using Microsoft.Extensions.Logging;
using SGA.Domain.Entitines.Configuration;
namespace SGA.Application.Services
{
    public sealed class RutaService : IRutaService
    {
        private readonly IRutaRepository _rutaRepository;
        private readonly ILogger<RutaService> _looger;

        public RutaService(IRutaRepository rutaRepository, ILogger<RutaService> looger)
        {
            _rutaRepository = rutaRepository;
            _looger = looger;
        }
        public async Task<ServiceResult> CreateRutaAsync(CreateRutaDto createRutaDto)
        {
            ServiceResult result = new ServiceResult();

            _looger.LogInformation("Iniciando la creación de una nueva ruta");

            try
            {
                // validaciones de negocio

                _looger.LogInformation("Validaciones de negocio completadas exitosamente");


                Ruta ruta = new Ruta
                {
                    Origen = createRutaDto.Origen,
                    Destino = createRutaDto.Destino,
                    FechaCreacion = createRutaDto.FechaCreacion,
                    UsuarioModificacion = createRutaDto.UsuarioCreacion
                };

                var opResult = await _rutaRepository.Save(ruta);

                if (!opResult.Success)
                {
                    _looger.LogWarning("No se pudo guardar la ruta en la base de datos.");
                    result.Success = false;
                    result.Message = opResult.Message;
                    return result;
                }

                result.Success = opResult.Success;
                result.Message = opResult.Message;
                result.Data = ruta;
                _looger.LogInformation("Ruta creada exitosamente con ID: {RutaId}", ruta.IdRuta);


            }
            catch (Exception ex)
            {

                _looger.LogError("Error al crear la ruta", ex.ToString());
                result.Success = false;
            }
            return result;
        }

        public async Task<ServiceResult> DeleteRutaAsync(RemoveRutaDto removeRutaDto)
        {
            ServiceResult result = new ServiceResult();

            _looger.LogInformation("Iniciando la eliminación de la ruta con ID: {RutaId}", removeRutaDto.Id);

            try
            {

                var opGetByIdResult = await _rutaRepository.GetEntityBy(removeRutaDto.Id);

                if (!opGetByIdResult.Success || opGetByIdResult.Data == null)
                {
                    _looger.LogWarning("No se encontró la ruta con ID: {RutaId}", removeRutaDto.Id);
                    result.Success = false;
                    result.Message = "Ruta no encontrada";
                    return result;
                }

                var ruta = (Ruta?)opGetByIdResult.Data;


                ruta!.FechaModificacion = removeRutaDto.RemoveDate;
                ruta.UsuarioModificacion = removeRutaDto.UserId;
                ruta.Estatus = removeRutaDto.IsRemoved;

                var opDeleteResult = await _rutaRepository.Remove(ruta);

                if (!opDeleteResult.Success)
                {
                    _looger.LogWarning("No se pudo eliminar la ruta con ID: {RutaId}", removeRutaDto.Id);
                    result.Success = false;
                    result.Message = opDeleteResult.Message;
                    return result;
                }
                result.Success = opDeleteResult.Success;
                result.Message = opDeleteResult.Message;
                _looger.LogInformation("Ruta eliminada exitosamente con ID: {RutaId}", removeRutaDto.Id);

            }
            catch (Exception ex)
            {
                _looger.LogError("Error al eliminar la ruta", ex.ToString());
                result.Success = false;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> GetAllRutasAsync()
        {
            ServiceResult serviceResult = new ServiceResult();
            _looger.LogInformation("Iniciando la obtención de todas las rutas");
            try
            {
                var opResult = await _rutaRepository.GetAll();

                if (!opResult.Success)
                {
                    _looger.LogWarning("No se pudieron obtener las rutas de la base de datos.");
                    serviceResult.Success = false;
                    serviceResult.Message = opResult.Message;
                    return serviceResult;
                }


                List<GetRutaDto> rutas = ((List<Ruta>)opResult.Data!).Select(rt => new GetRutaDto() 
                {
                    Id = rt.IdRuta,
                    Origen = rt.Origen,
                    Destino = rt.Destino,
                    FechaCreacion = rt.FechaCreacion
                }).ToList();

                serviceResult.Success = opResult.Success;
                serviceResult.Message = opResult.Message;
                serviceResult.Data = opResult.Data;

            }
            catch (Exception ex)
            {

                _looger.LogError("Error al obtener las rutas", ex.ToString());
                serviceResult.Success = false;
                return serviceResult;
            }
            return serviceResult;
        }

        public async Task<ServiceResult> GetRutaByIdAsync(int id)
        {
           ServiceResult serviceResult = new ServiceResult();

            _looger.LogInformation("Iniciando la obtención de la ruta con ID: {RutaId}", id);

            try
            {
                var opResult = await _rutaRepository.GetEntityBy(id);

                if (!opResult.Success || opResult.Data == null)
                {
                    _looger.LogWarning("No se encontró la ruta con ID: {RutaId}", id);
                    serviceResult.Success = false;
                    serviceResult.Message = "Ruta no encontrada";
                    return serviceResult;
                }

                var ruta = (Ruta?)opResult.Data;

                GetRutaDto rutaDto = new GetRutaDto
                {
                    Id = ruta!.IdRuta,
                    Origen = ruta.Origen,
                    Destino = ruta.Destino,
                    FechaCreacion = ruta.FechaCreacion
                };

                serviceResult.Success = opResult.Success;
                serviceResult.Message = opResult.Message;
                serviceResult.Data = rutaDto;
            }
            catch (Exception ex)
            {
                _looger.LogError("Error al obtener la ruta", ex.ToString());
                serviceResult.Success = false;
                return serviceResult;
            }
            return serviceResult;
        }

        public async Task<ServiceResult> UpdateRutaAsync(UpdateRutaDto updateRutaDto)
        {
            ServiceResult result = new ServiceResult();
            _looger.LogInformation("Iniciando la actualización de la ruta con ID: {RutaId}", updateRutaDto.Id);
            try
            {
                var opGetByIdResult = await _rutaRepository.GetEntityBy(updateRutaDto.Id);

                if (!opGetByIdResult.Success || opGetByIdResult.Data == null)
                {
                    _looger.LogWarning("No se encontró la ruta con ID: {RutaId}", updateRutaDto.Id);
                    result.Success = false;
                    result.Message = "Ruta no encontrada";
                    return result;
                }

                var ruta = (Ruta?)opGetByIdResult.Data;
                ruta!.Origen = updateRutaDto.Origen;
                ruta.Destino = updateRutaDto.Destino;
                ruta.FechaModificacion = updateRutaDto.FechaModificacion;
                ruta.UsuarioModificacion = updateRutaDto.UsuarioModificacion;
                var opUpdateResult = await _rutaRepository.Update(ruta);

                if (!opUpdateResult.Success)
                {
                    _looger.LogWarning("No se pudo actualizar la ruta con ID: {RutaId}", updateRutaDto.Id);
                    result.Success = false;
                    result.Message = opUpdateResult.Message;
                    return result;
                }

                result.Success = opUpdateResult.Success;
                result.Message = opUpdateResult.Message;
                result.Data = ruta;
                _looger.LogInformation("Ruta actualizada exitosamente con ID: {RutaId}", updateRutaDto.Id);
            }
            catch (Exception ex)
            {
                _looger.LogError("Error al actualizar la ruta", ex.ToString());
                result.Success = false;
                return result;
            }
            return result;

        }
    }
}

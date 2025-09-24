

using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
        private readonly ILogger<RutaRepository> _logger;

        public RutaRepository(SGAContext context, 
                              ILogger<RutaRepository> logger) : base(context)
        {
            _logger = logger;
        }
        public async override Task<OperationResult> Save(Ruta entity)
        {

            OperationResult result = new OperationResult();

            _logger.LogInformation($"Inicie el proceso de guardado de la ruta {entity.Destino}");


            // validaciones de campos //
            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad ruta no puede ser nula";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Destino))
            {
                result.Success = false;
                result.Message = "El destino de la ruta es requerido.";
                return result;
            }
            if (entity.Destino.Length > 50)
            {
                result.Success = false;
                result.Message = "El destino tiene una longitud inválida.";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Origen))
            {
                result.Success = false;
                result.Message = "El origen de la ruta es requerido.";
                return result;
            }
            if (entity.Origen.Length > 50)
            {
                result.Success = false;
                result.Message = "El origen tiene una longitud inválida.";
                return result;
            }

            if (await base.Exists(cd => cd.Destino == entity.Destino && cd.Origen == entity.Origen))
            {
                result.Success = false;
                result.Message = $"La ruta para el origen: {entity.Origen} y el destino: {entity.Destino} se encuentra registrada.";
                return result;
            }
            try
            {
                await base.Save(entity);

                GetRutaDto getRutaDto = new GetRutaDto()
                {
                    Destino = entity.Destino,
                    Origen = entity.Origen,
                    Id = entity.IdRuta
                };

                result.Message = "La ruta fue creada correctamente.";
                result.Data = getRutaDto;

                _logger.LogInformation("La ruta fue creada correctamente.");


            }
            catch (Exception ex)
            {
                
                _logger.LogError($"Error guardando el bus: {ex.Message}");
                result.Success = false;
                result.Message = "Error guardando el bus.";
            }

            return result;
        }

        public async override Task<OperationResult> Update(Ruta entity)
        {
            OperationResult result = new OperationResult();

            // validaciones de campos //
            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad ruta no puede ser nula";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Destino))
            {
                result.Success = false;
                result.Message = "El destino de la ruta es requerido.";
                return result;
            }
            if (entity.Destino.Length > 50)
            {
                result.Success = false;
                result.Message = "El destino tiene una longitud inválida.";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Origen))
            {
                result.Success = false;
                result.Message = "El origen de la ruta es requerido.";
                return result;
            }
            if (entity.Origen.Length > 50)
            {
                result.Success = false;
                result.Message = "El origen tiene una longitud inválida.";
                return result;
            }


            try
            {
                
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error guardando el bus: {ex.Message}");
                result.Success = false;
                result.Message = "Error guardando el bus.";
            }

            return result;
        }


    }
}

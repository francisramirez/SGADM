
using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Bus;
using SGA.Application.Interfaces;
using SGA.Application.Repositories.Confguration;
using Microsoft.Extensions.Logging;
using SGA.Domain.Entitines.Configuration;
namespace SGA.Application.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly ILogger<BusService> _logger;

        public BusService(IBusRepository busRepository,
                          ILogger<BusService> logger)
        {
            _busRepository = busRepository;
            _logger = logger;
        }
        public async Task<ServiceResult> CreateBus(CreateBusDto createBusDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation("Creating a new bus with plate number: {PlateNumber}", createBusDto.NumeroPlaca);

                if (createBusDto is null)
                {
                    result.Success = false;
                    result.Message = "The bus data is null.";
                    return result;
                }

                Bus bus = new Bus()
                {
                    Nombre = createBusDto.Nombre,
                    NumeroPlaca = createBusDto.NumeroPlaca,
                    CapacidadPiso1 = createBusDto.CapacidadPiso1,
                    CapacidadPiso2 = createBusDto.CapacidadPiso2,
                    Disponible = createBusDto.Disponible
                };


                var opResult = await _busRepository.Save(bus);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = " An error occurred while creating the bus.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetBusById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                _logger.LogInformation("Retrieving bus with ID: {BusId}", id);

                var oResultGetEntity = await _busRepository.GetEntityBy(id);

                if (!oResultGetEntity.Success)
                {
                    result.Success = oResultGetEntity.Success;
                    result.Message = oResultGetEntity.Message;
                    return result;
                }

                result.Success = true;
                result.Message = oResultGetEntity.Message;
                result.Data = oResultGetEntity.Data;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "An error occurred while retrieving the bus.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public async Task<ServiceResult> GetBuses()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                _logger.LogInformation("Retrieving all buses");

                var oResultGetEntities = await _busRepository.GetAll();

                if (!oResultGetEntities.Success)
                {
                    result.Success = oResultGetEntities.Success;
                    result.Message = oResultGetEntities.Message;
                    return result;
                }
                result.Success = true;
                result.Message = oResultGetEntities.Message;
                result.Data = oResultGetEntities.Data;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "An error occurred while retrieving buses.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public async Task<ServiceResult> RemoveBus(RemoveBusDto removeBusDto)
        {
            ServiceResult result = new ServiceResult();

            _logger.LogInformation("Removing a bus with Bus Id: {IdBus}", removeBusDto.IdBus);

            try
            {

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "An error occurred while removing buses.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<ServiceResult> UpdateBus(UpdateBusDto updateBusDto)
        {
            ServiceResult result = new ServiceResult();

            _logger.LogInformation("Updating a bus with plate number: {PlateNumber}", updateBusDto.NumeroPlaca);

            try
            {
                Bus bus = new Bus()
                {
                    IdBus = updateBusDto.IdBus,
                    Nombre = updateBusDto.Nombre,
                    NumeroPlaca = updateBusDto.NumeroPlaca,
                    CapacidadPiso1 = updateBusDto.CapacidadPiso1,
                    CapacidadPiso2 = updateBusDto.CapacidadPiso2,
                    Disponible = updateBusDto.Disponible
                };
                var oResultGetEntity = await _busRepository.Update(bus);

                if (!oResultGetEntity.Success)
                {
                    result.Success = oResultGetEntity.Success;
                    result.Message = oResultGetEntity.Message;
                    return result;
                }

                result.Success = true;
                result.Message = oResultGetEntity.Message;
                result.Data = oResultGetEntity.Data;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "An error occurred while updating buses.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}



using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Bus;

namespace SGA.Application.Extentions
{
    public static class ValidateBus
    {
        public static ServiceResult IsValidBuDto(this BusDto busDto)
        {
            ServiceResult serviceResult = new ServiceResult() 
            { 
                Success = true,
                Message = "Datos Válidos" 
            };

            if (busDto == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "El objeto bus no puede ser nulo."
                };
            }
            if (string.IsNullOrWhiteSpace(busDto.NumeroPlaca) || string.IsNullOrWhiteSpace(busDto.Nombre))
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "El objeto bus no puede ser nulo."
                };
            }
            if (busDto.CapacidadPiso1 < 0 || busDto.CapacidadPiso2 < 0)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "El objeto bus no puede ser nulo."
                };
            }

            return serviceResult;
        }
    }
}

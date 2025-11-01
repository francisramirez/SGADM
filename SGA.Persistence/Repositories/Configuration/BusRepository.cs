

using SGA.Application.Repositories.Confguration;
using SGA.Domain.Base;
using SGA.Domain.Entitines.Configuration;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories.Configuration
{
    public sealed class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        private readonly SGAContext context;

        public BusRepository(SGAContext context) : base(context)
        {
            this.context = context;
        }
        public async override Task<OperationResult> Save(Bus entity)
        {
            OperationResult operationResult = new OperationResult();
          
            // validaciones de datos

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "El objeto bus no puede ser nulo.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.NumeroPlaca))
            {
                operationResult.Success = false;
                operationResult.Message = "El número de placa no puede ser nulo o vacío.";
                return operationResult;
            }
            if (entity.NumeroPlaca.Length > 50)
            {
                operationResult.Success = false;
                operationResult.Message = "La longitud del número de placa es inválida.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.Nombre))
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre del bus no puede ser nulo o vacío.";
                return operationResult;
            }
            if (entity.Nombre.Length > 50)
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre del bus no puede tener más de 50 caracteres.";
                return operationResult;
            }
            operationResult.Success = true;
            operationResult.Message = "El bus fue creado correctamente.";


            await base.Save(entity);

            return operationResult;
        }
        public override Task<OperationResult> Update(Bus entity)
        {
            // You can add custom logic here if needed before updating
            return base.Update(entity);
        }
    }
}

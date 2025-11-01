

using Microsoft.EntityFrameworkCore;
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
        public override async Task<OperationResult> Update(Bus entity)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                Bus busToupdate = await context.Buses.FindAsync(entity.IdBus);

                if (busToupdate == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "Bus no encontrado.";
                    return operationResult;
                }

                busToupdate.Nombre =  entity.Nombre;
                busToupdate.NumeroPlaca = entity.NumeroPlaca;
                busToupdate.CapacidadPiso1 = entity.CapacidadPiso1;
                busToupdate.CapacidadPiso2 = entity.CapacidadPiso2;
                busToupdate.Disponible = entity.Disponible;
                busToupdate.UsuarioModificacion = entity.UsuarioModificacion;
                busToupdate.FechaModificacion = entity.FechaModificacion;

                context.Buses.Update(busToupdate);
                await context.SaveChangesAsync();

                operationResult.Success = true;
                operationResult.Message = "Bus actualizado correctamente.";
            }
            catch (Exception ex)
            {

                operationResult.Success = false;
                operationResult.Message = "Error al actualizar el bus: " + ex.Message;
               
            }
            return operationResult;
        }

        public override async Task<OperationResult> GetAll()
        {
           OperationResult operationResult = new OperationResult();
            try
            {

                var query = await (from b in context.Buses
                            where b.Estatus == true
                            orderby b.FechaCreacion descending
                            select b).ToListAsync();

              
                operationResult.Data = query;
                operationResult.Success = true;
                operationResult.Message = "Buses recuperados correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error al recuperar los buses: " + ex.Message;
            }
            return operationResult;
        }
    }
}

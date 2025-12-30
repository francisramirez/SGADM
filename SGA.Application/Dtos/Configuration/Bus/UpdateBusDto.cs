

using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.Configuration.Bus
{
    public record UpdateBusDto : BusDto
    {
        public int IdBus { get; set; }

      
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioActualizacion { get; set; }
    }
}

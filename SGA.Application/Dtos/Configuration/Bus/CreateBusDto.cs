

using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.Configuration.Bus
{
    public record CreateBusDto : BusDto
    {
       
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacion { get; set; }
    }
}

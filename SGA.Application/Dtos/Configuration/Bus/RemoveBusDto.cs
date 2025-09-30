

namespace SGA.Application.Dtos.Configuration.Bus
{
    public record RemoveBusDto
    {
        public int IdBus { get; set; }
        public DateTime FechaEliminacion { get; set; }
        public int UsuarioEliminacion { get; set; }
    }
}

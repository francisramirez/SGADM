

namespace SGA.Application.Dtos.Configuration.Ruta
{
    public record UpdateRutaDto
    {
        public int Id { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModificacion { get; set; }
    }
}

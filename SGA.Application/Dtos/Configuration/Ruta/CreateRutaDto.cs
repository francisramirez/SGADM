
namespace SGA.Application.Dtos.Configuration.Ruta
{
    public record CreateRutaDto
    {
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacion { get; set; }
    }
}

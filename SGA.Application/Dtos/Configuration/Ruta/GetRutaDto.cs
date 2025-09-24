

namespace SGA.Application.Dtos.Configuration.Ruta
{
    public record GetRutaDto
    {
        public int Id { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
    }
}

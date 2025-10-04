

namespace SGA.Application.Dtos.Configuration.Ruta
{
    public record RemoveRutaDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RemoveDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}

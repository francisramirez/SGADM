

using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.Configuration.Bus
{
    public record UpdateBusDto
    {
        public int IdBus { get; set; }

        [Required(ErrorMessage = "El numero de placa es requerido")]
        [MaxLength(50, ErrorMessage = "El numero de placa no debe exceder los 50 caracteres")]
        [MinLength(15, ErrorMessage = "El numero de placa debe tener al menos 15 caracteres")]

        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public bool Disponible { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioActualizacion { get; set; }
    }
}

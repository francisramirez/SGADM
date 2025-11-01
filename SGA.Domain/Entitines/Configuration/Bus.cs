

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGA.Domain.Entitines.Configuration
{
    [Table("Bus")]
    public sealed class Bus : Base.BaseEntity
    {
        public Bus()
        {
            this.Estatus = true;
        }
        [Key]
        public int IdBus { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public bool Disponible { get; set; }
    }
}




using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGA.Domain.Entitines.Configuration
{

    [Table("Ruta")]
    public sealed class Ruta : Base.BaseEntity
    {
        [Key]
        public int IdRuta { get; set; }

        public string? Origen { get; set; }

        public string? Destino { get; set; }
    }
}




namespace SGA.Domain.Entitines.Configuration
{
    public sealed class Ruta : Base.BaseEntity
    {
        public int IdRuta { get; set; }

        public string? Origen { get; set; }

        public string? Destino { get; set; }
    }
}

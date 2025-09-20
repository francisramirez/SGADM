

namespace SGA.Domain.Entitines.Configuration
{
    public sealed class Asiento : Base.BaseEntity
    {
        public int IdAsiento { get; set; }
        public string? NumeroAsiento { get; set; }
        public int Piso { get; set; }
        public bool Disponible { get; set; }
        public int IdBus { get; set; }
        
    }
}

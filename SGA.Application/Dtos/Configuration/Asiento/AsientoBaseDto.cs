

namespace SGA.Application.Dtos.Configuration.Asiento
{
    public abstract record AsientoBaseDto
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
    }
}

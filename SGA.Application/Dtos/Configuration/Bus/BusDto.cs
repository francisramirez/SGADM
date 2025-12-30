

using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.Configuration.Bus
{
    public abstract record BusDto 
    {
      
        public string? NumeroPlaca { get; set; }


        public string? Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public bool Disponible { get; set; }
    }
}

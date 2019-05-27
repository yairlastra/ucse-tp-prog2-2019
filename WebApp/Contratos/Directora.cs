using System;

namespace Contratos
{
    public class Directora : Usuario
    {
        public Institucion Institucion { get; set; }
        public string Cargo { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
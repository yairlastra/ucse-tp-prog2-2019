using System;

namespace Contratos
{
    public class Comentario
    {
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
    }
}
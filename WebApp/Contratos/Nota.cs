using System;

namespace Contratos
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaEventoAsociado { get; set; }
        public bool Leida { get; set; }
        public Comentario[] Comentarios { get; set; }
    }
}
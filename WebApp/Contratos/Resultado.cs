using System.Collections.Generic;

namespace Contratos
{
    public class Resultado
    {        
        public List<string> Errores = new List<string>();
        public bool EsValido { get { return this.Errores.Count == 0; } }
    }
}
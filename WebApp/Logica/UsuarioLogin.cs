using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;

namespace Logica
{
    public class UsuarioLogin : Usuario
    {
        public int Clave { get; set; }
        public Roles[] Roles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Contratos;

namespace Logica
{
    public sealed class Principal
    {
        private readonly static Principal instancia = new Principal();

        public static Principal Instancia { get { return instancia; } }

        private Principal() { }

        public Institucion[] ObtenerInstituciones()
        { return Archivos.Instancia.ObtenerInstituciones(); }

        public Padre ObtenerPadrePorId(UsuarioLogueado usuarioLogueado, int id)
        { return Archivos.Instancia.ObtenerPadres().First(x => x.Id == id); }


    }
}

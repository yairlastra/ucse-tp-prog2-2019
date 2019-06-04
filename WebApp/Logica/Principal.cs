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

        public Padre ObtenerPadrePorId(int id)
        { return Archivos.Instancia.ObtenerPadres().First(x => x.Id == id); }

        public Docente ObtenerDocentePorId(int id)
        { return Archivos.Instancia.ObtenerDocentes().First(x => x.Id == id); }

        public Directora ObtenerDirectoraPorId(int id)
        { return Archivos.Instancia.ObtenerDirectoras().First(x => x.Id == id); }

        public Hijo ObtenerAlumnoPorId(int id)
        { return Archivos.Instancia.ObtenerHijos().First(x => x.Id == id); }

        // este metodo de abejo no me deja conforme

        public Resultado EditarDirectora(int id, Directora directora)
        {
            Directora[] Directoras = Archivos.Instancia.ObtenerDirectoras().Where(x => x.Id != id).ToArray();
            Directoras[Directoras.Length] = directora;
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }





    }
}

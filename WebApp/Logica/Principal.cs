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

        public Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado)
        {
            Directora[] Directoras = Archivos.Instancia.ObtenerDirectoras().ToArray();
            directora.Id = (Directoras.Length) + 1;
            Directoras[Directoras.Length] = directora;
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }

        public Resultado AltaDocente(Docente docente, UsuarioLogueado usuarioLogueado)
        {
            Docente[] Docentes = Archivos.Instancia.ObtenerDocentes().ToArray();
            docente.Id = (Docentes.Length) + 1;
            Docentes[Docentes.Length] = docente;
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado AltaPadre(Padre padre, UsuarioLogueado usuarioLogueado)
        {
            Padre[] Padres = Archivos.Instancia.ObtenerPadres().ToArray();
            padre.Id = (Padres.Length) + 1;
            Padres[Padres.Length] = padre;
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado AltaHijo(Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            Hijo[] Hijos = Archivos.Instancia.ObtenerHijos().ToArray();
            hijo.Id = (Hijos.Length) + 1;
            Hijos[Hijos.Length] = hijo;
            Archivos.Instancia.ModificarArchivoHijos(Hijos);
            return new Resultado();
        }



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

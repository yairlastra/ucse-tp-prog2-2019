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
        { return Archivos.Instancia.ObtenerInstituciones().ToArray(); }

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
            List<Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            directora.Id = (Directoras.Count) + 1;
            Directoras.Add(directora);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras.ToList());
            return new Resultado();
        }

        public Resultado AltaDocente(Docente docente, UsuarioLogueado usuarioLogueado)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes();
            docente.Id = (Docentes.Count) + 1;
            Docentes.Add(docente);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado AltaPadre(Padre padre, UsuarioLogueado usuarioLogueado)
        {
            List<Padre> Padres = Archivos.Instancia.ObtenerPadres();
            padre.Id = (Padres.Count) + 1;
            Padres.Add(padre);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado AltaHijo(Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            List<Hijo> Hijos = Archivos.Instancia.ObtenerHijos();
            hijo.Id = (Hijos.Count) + 1;
            Hijos.Add(hijo);
            Archivos.Instancia.ModificarArchivoHijos(Hijos);
            return new Resultado();
        }



        // este metodo de abejo no me deja conforme

        public Resultado EditarDirectora(int id, Directora directora)
        {
            List<Directora> Directoras = Archivos.Instancia.ObtenerDirectoras();
            Directoras.RemoveAll(x => x.Id == id);
            Directoras.Add(directora);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }

        public Resultado EliminarDirectora(int id)
        {
            List <Directora> Directoras = Archivos.Instancia.ObtenerDirectoras();
            Directoras.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }

        public Grilla<Directora> ObtenerDirectoras(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Directora>()
            {
                Lista = Archivos.Instancia.ObtenerDirectoras().Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Archivos.Instancia.ObtenerDirectoras().ToList().Count
            };
        }



    }
}

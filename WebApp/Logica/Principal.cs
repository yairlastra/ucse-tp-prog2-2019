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



        public Hijo ObtenerAlumnoPorId(int id)
        { return Archivos.Instancia.ObtenerHijos().First(x => x.Id == id); }

        public Padre ObtenerPadrePorId(int id)
        { return Archivos.Instancia.ObtenerPadres().First(x => x.Id == id); }

        public Docente ObtenerDocentePorId(int id)
        { return Archivos.Instancia.ObtenerDocentes().First(x => x.Id == id); }

        public Directora ObtenerDirectoraPorId(int id)
        { return Archivos.Instancia.ObtenerDirectoras().First(x => x.Id == id); }



        public Resultado AltaHijo(Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            List<Hijo> Hijos = Archivos.Instancia.ObtenerHijos().ToList();
            hijo.Id = (Hijos.Count) + 1;
            Hijos.Add(hijo);
            Archivos.Instancia.ModificarArchivoHijos(Hijos);
            return new Resultado();
        }

        public Resultado AltaPadre(Padre padre, UsuarioLogueado usuarioLogueado)
        {
            List<Padre> Padres = Archivos.Instancia.ObtenerPadres().ToList();
            padre.Id = (Padres.Count) + 1;
            Padres.Add(padre);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado AltaDocente(Docente docente, UsuarioLogueado usuarioLogueado)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            docente.Id = (Docentes.Count) + 1;
            Docentes.Add(docente);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado)
        {
            List<Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            directora.Id = (Directoras.Count) + 1;
            Directoras.Add(directora);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }



        public Resultado EditarHijo(int id, Hijo hijo)
        {
            List<Hijo> Hijos = Archivos.Instancia.ObtenerHijos().ToList();
            Hijos.RemoveAll(x => x.Id == id);
            Hijos.Add(hijo);
            Archivos.Instancia.ModificarArchivoHijos(Hijos);
            return new Resultado();
        }

        public Resultado EditarPadre(int id, Padre padre)
        {
            List<Padre> Padres = Archivos.Instancia.ObtenerPadres().ToList();
            Padres.RemoveAll(x => x.Id == id);
            Padres.Add(padre);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado EditarDocente(int id, Docente docente)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            Docentes.RemoveAll(x => x.Id == id);
            Docentes.Add(docente);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado EditarDirectora(int id, Directora directora)
        {
            List<Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            Directoras.RemoveAll(x => x.Id == id);
            Directoras.Add(directora);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }



        public Resultado EliminarHijo(int id)
        {
            List<Hijo> Hijos = Archivos.Instancia.ObtenerHijos().ToList();
            Hijos.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoHijos(Hijos);
            return new Resultado();
        }

        public Resultado EliminarPadre(int id)
        {
            List<Padre> Padres = Archivos.Instancia.ObtenerPadres().ToList();
            Padres.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado EliminarDocente(int id)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            Docentes.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado EliminarDirectora(int id)
        {
            List <Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            Directoras.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        } 



        public Grilla<Hijo> ObtenerGrillaAlumnos(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Hijo>()
            {
                Lista = Archivos.Instancia.ObtenerHijos().Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Archivos.Instancia.ObtenerHijos().ToList().Count
            };
        }

        public Grilla<Padre> ObtenerGrillaPadres(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Padre>()
            {
                Lista = Archivos.Instancia.ObtenerPadres().Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Archivos.Instancia.ObtenerPadres().ToList().Count
            };
        }

        public Grilla<Docente> ObtenerGrillaDocentes(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Docente>()
            {
                Lista = Archivos.Instancia.ObtenerDocentes().Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Archivos.Instancia.ObtenerDocentes().ToList().Count
            };
        }

        public Grilla<Directora> ObtenerGrillaDirectoras(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Directora>()
            {
                Lista = Archivos.Instancia.ObtenerDirectoras().Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Archivos.Instancia.ObtenerDirectoras().ToList().Count
            };
        }

    }
}

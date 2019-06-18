using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;
using Logica;

namespace Implementacion
{
    public class ImplementacionService : IServicioWeb
    {





        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************
        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************
        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************
        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************



        public Grilla<Hijo> ObtenerAlumnos(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            {
                

                throw new NotImplementedException();
            }
            else
            { return Principal.Instancia.ObtenerGrillaAlumnos(paginaActual, totalPorPagina, busquedaGlobal); }
        }

        public Grilla<Padre> ObtenerPadres(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerGrillaPadres(paginaActual, totalPorPagina, busquedaGlobal); }
        }

        public Grilla<Docente> ObtenerDocentes(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerGrillaDocentes(paginaActual, totalPorPagina, busquedaGlobal); }
        }

        public Grilla<Directora> ObtenerDirectoras(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerGrillaDirectoras(paginaActual, totalPorPagina, busquedaGlobal); }   
        }

        public UsuarioLogueado ObtenerUsuario(string email, string clave)
        { return Principal.Instancia.ObtenerUsuario(email, clave); }

        public Hijo[] ObtenerPersonas(UsuarioLogueado usuarioLogueado)
        { return Principal.Instancia.ObtenerPersonas(usuarioLogueado); }





        public Resultado EliminarAlumno(int id, Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EliminarHijo(id); }
        }

        public Resultado EliminarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EliminarPadre(id); }
        }

        public Resultado EliminarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EliminarDocente(id); }
        }

        public Resultado EliminarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EliminarDirectora(id); }
        }





        public Resultado EditarAlumno(int id, Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EditarHijo(id, hijo); }
        }

        public Resultado EditarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EditarPadre(id, padre); }
        }

        public Resultado EditarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EditarDocente(id, docente); }
        }

        public Resultado EditarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.EditarDirectora(id, directora); }
        }





        public Resultado AltaAlumno(Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AltaHijo(hijo); }
        }

        public Resultado AltaPadreMadre(Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AltaPadre(padre); }
        }

        public Resultado AltaDocente(Docente docente, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AltaDocente(docente); }
        }

        public Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AltaDirectora(directora); }
        }

        public Resultado AltaNota(Nota nota, Sala[] salas, Hijo[] hijos, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AltaNota(nota,salas,hijos); }
        }





        public Hijo ObtenerAlumnoPorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerAlumnoPorId(id); }
        }

        public Padre ObtenerPadrePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerPadrePorId(id); }
        }

        public Docente ObtenerDocentePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerDocentePorId(id); }
        }

        public Directora ObtenerDirectoraPorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerDirectoraPorId(id); }
        }

        public Institucion[] ObtenerInstituciones()
        { return Principal.Instancia.ObtenerInstituciones(); }





        public string ObtenerNombreGrupo()
        { return $"Lastra - Belmonte - Balaudo"; }

        public Sala[] ObtenerSalasPorInstitucion(UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora) && !usuarioLogueado.Roles.Contains(Roles.Docente))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.ObtenerSalasPorInstitucion(); }
        }

        public Resultado MarcarNotaComoLeida(Nota nota, UsuarioLogueado usuarioLogueado)
        { return Logica.Principal.Instancia.MarcarNotaComoLeida(nota, usuarioLogueado); }

        public Resultado ResponderNota(Nota nota, Comentario nuevoComentario, UsuarioLogueado usuarioLogueado)
        {
            return Logica.Principal.Instancia.ResponderNota(nota, nuevoComentario, usuarioLogueado);
        }





        public Resultado AsignarHijoPadre(Hijo hijo, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AsignarHijoPadre(hijo,padre); }
        }

        public Resultado DesasignarHijoPadre(Hijo hijo, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.DesasignarHijoPadre(hijo, padre); }
        }

        public Resultado AsignarDocenteSala(Docente docente, Sala sala, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.AsignarDocenteSala(docente, sala); }
        }

        public Resultado DesasignarDocenteSala(Docente docente, Sala sala, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Principal.Instancia.DesasignarDocenteSala(docente, sala); }
        }

        public Nota[] ObtenerCuadernoComunicaciones(int idPersona, UsuarioLogueado usuarioLogueado)
        { return Logica.Principal.Instancia.ObtenerPersonas(usuarioLogueado).First(x => x.Id == idPersona).Notas; }


    }
}

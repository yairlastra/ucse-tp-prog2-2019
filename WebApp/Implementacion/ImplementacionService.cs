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

        public Resultado AltaNota(Nota nota, Sala[] salas, Hijo[] hijos, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Resultado AsignarDocenteSala(Docente docente, Sala sala, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Resultado AsignarHijoPadre(Hijo hijo, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Resultado DesasignarDocenteSala(Docente docente, Sala sala, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Resultado DesasignarHijoPadre(Hijo hijo, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Resultado MarcarNotaComoLeida(Nota nota, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }




        public Nota[] ObtenerCuadernoComunicaciones(int idPersona, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }


        public Hijo[] ObtenerPersonas(UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Sala[] ObtenerSalasPorInstitucion(UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }



        public Resultado ResponderNota(Nota nota, Comentario nuevoComentario, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }


        public UsuarioLogueado ObtenerUsuario(string email, string clave)
        {
            if (email == "" || clave == "")
                return null;

            if (email == "directora@ucse.com" && clave == "123456")
                return new UsuarioLogueado() { Email = email, Nombre = "Usuario", Apellido = "Directora", Roles = new Roles[] { Roles.Directora }, RolSeleccionado = Roles.Directora };

            if (email == "docente@ucse.com" && clave == "123456")
                return new UsuarioLogueado() { Email = email, Nombre = "Usuario", Apellido = "Docente", Roles = new Roles[] { Roles.Docente }, RolSeleccionado = Roles.Docente };

            if (email == "padre@ucse.com" && clave == "123456")
                return new UsuarioLogueado() { Email = email, Nombre = "Usuario", Apellido = "Padre", Roles = new Roles[] { Roles.Padre }, RolSeleccionado = Roles.Padre };

            return null;
        }

        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************
        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************
        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************
        // IMPLEMENTACIONES COMPLETADAS ****************************************************************************************************


        
        public Grilla<Hijo> ObtenerAlumnos(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerGrillaAlumnos(paginaActual, totalPorPagina, busquedaGlobal); }
        }

        public Grilla<Padre> ObtenerPadres(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerGrillaPadres(paginaActual, totalPorPagina, busquedaGlobal); }
        }

        public Grilla<Docente> ObtenerDocentes(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerGrillaDocentes(paginaActual, totalPorPagina, busquedaGlobal); }
        }

        public Grilla<Directora> ObtenerDirectoras(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerGrillaDirectoras(paginaActual, totalPorPagina, busquedaGlobal); }   
        }



        public Resultado EliminarAlumno(int id, Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EliminarHijo(id); }
        }

        public Resultado EliminarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EliminarPadre(id); }
        }

        public Resultado EliminarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EliminarDocente(id); }
        }

        public Resultado EliminarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EliminarDirectora(id); }
        }



        public Resultado EditarAlumno(int id, Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EditarHijo(id, hijo); }
        }

        public Resultado EditarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EditarPadre(id, padre); }
        }

        public Resultado EditarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EditarDocente(id, docente); }
        }

        public Resultado EditarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.EditarDirectora(id, directora); }
        }



        public Resultado AltaAlumno(Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.AltaHijo(hijo, usuarioLogueado); }
        }

        public Resultado AltaPadreMadre(Padre padre, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.AltaPadre(padre, usuarioLogueado); }
        }

        public Resultado AltaDocente(Docente docente, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.AltaDocente(docente, usuarioLogueado); }
        }

        public Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.AltaDirectora(directora, usuarioLogueado); }
        }

        public Hijo ObtenerAlumnoPorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerAlumnoPorId(id); }
        }

        public Padre ObtenerPadrePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerPadrePorId(id); }
        }

        public Docente ObtenerDocentePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerDocentePorId(id); }
        }

        public Directora ObtenerDirectoraPorId(UsuarioLogueado usuarioLogueado, int id)
        {
            if (!usuarioLogueado.Roles.Contains(Roles.Directora))
            { throw new NotImplementedException(); }
            else
            { return Logica.Principal.Instancia.ObtenerDirectoraPorId(id); }
        }

        public Institucion[] ObtenerInstituciones()
        { return Logica.Principal.Instancia.ObtenerInstituciones(); }

        public string ObtenerNombreGrupo()
        { return $"Lastra - Belmonte - Balaudo"; }
    }
}

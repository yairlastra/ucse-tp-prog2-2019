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

        public Hijo[] ObtenerPersonas(UsuarioLogueado usuarioLogueado)
        {
            List<Hijo> ListaHijos = Archivos.Instancia.ObtenerHijos();
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Padre:
                    Padre padre = Archivos.Instancia.ObtenerPadres().Find(x => x.Nombre == usuarioLogueado.Nombre && x.Apellido == usuarioLogueado.Apellido);
                    return ListaHijos.Where(x => padre.Hijos.Contains(x)).ToArray();
                case Roles.Directora:
                    return ListaHijos.ToArray();
                case Roles.Docente:
                    Docente docente = Archivos.Instancia.ObtenerDocentes().Find(x => x.Nombre == usuarioLogueado.Nombre && x.Apellido == usuarioLogueado.Apellido);
                    return ListaHijos.Where(x => docente.Salas.Contains(x.Sala)).ToArray();
                default:
                    throw new Exception("Rol no implementado");
            }
        }

        public UsuarioLogueado ObtenerUsuario(string email, string clave)
       {
            if (email == "" || clave == "")
            { return null; }

            UsuarioLogin usuario = Archivos.Instancia.ObtenerUsuarios().Find(x => x.Email == email && x.Clave == clave);

            if (usuario is null)
            { return null; }
            else
            { return  ConvercionDeUsuario(usuario); }   
       }



        public Resultado AltaHijo(Hijo hijo)
        {
            List<Hijo> Hijos = Archivos.Instancia.ObtenerHijos().ToList();
            hijo.Id = (Hijos.Count == 0 ? 0 : Hijos.Max(x => x.Id)) + 1;
            hijo.Notas = new Nota[] {};
            Hijos.Add(hijo);
            Archivos.Instancia.ModificarArchivoHijos(Hijos);
            return new Resultado();
        }

        public Resultado AltaPadre(Padre padre)
        {
            List<Padre> Padres = Archivos.Instancia.ObtenerPadres().ToList();
            padre.Id = (Padres.Count == 0 ? 0 : Padres.Max(x => x.Id)) + 1;
            Padres.Add(padre);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            UsuarioLogin usuario = ConvercionDeUsuario((Usuario)padre, Roles.Padre);
            AltaUsuario(usuario);
            return new Resultado();
        }

        public Resultado AltaDocente(Docente docente)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            docente.Id = (Docentes.Count == 0 ? 0 : Docentes.Max(x => x.Id)) + 1;
            docente.Salas = new Sala[] { };
            Docentes.Add(docente);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            UsuarioLogin usuario = ConvercionDeUsuario((Usuario)docente, Roles.Docente);
            AltaUsuario(usuario);
            return new Resultado();
        }

        public Resultado AltaDirectora(Directora directora)
        {
            List<Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            directora.Id = (Directoras.Count == 0 ? 0 : Directoras.Max(x => x.Id)) + 1;
            Directoras.Add(directora);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            UsuarioLogin usuario = ConvercionDeUsuario((Usuario)directora, Roles.Directora);
            AltaUsuario(usuario);
            return new Resultado();
        }

        public Resultado AltaNota(Nota nota, Sala[] salas, Hijo[] hijos)
        {
            List<Hijo> ListaHijos = Archivos.Instancia.ObtenerHijos();

            if (hijos == null || hijos.Length >= 0)
            {
                hijos = new Hijo[] { };
                foreach (var sala in salas)
                { hijos.Concat(ListaHijos.Where(x => x.Sala.Id == sala.Id)); }
            }

            foreach (int id in hijos.ToList().Select(x => x.Id))
            {
                Hijo hijo = ListaHijos.Single(x => x.Id == id);
                if (hijo.Notas is null)
                { hijo.Notas = new Nota[] { nota }; }
                else
                { hijo.Notas[hijo.Notas.Length] = nota; };
            }

            Archivos.Instancia.ModificarArchivoHijos(ListaHijos);

            return new Resultado();
        }

        private void AltaUsuario(UsuarioLogin usuario)
        {
            List<UsuarioLogin> usuarios = Archivos.Instancia.ObtenerUsuarios().ToList();
            UsuarioLogin existente = usuarios.Find(x => x.Email == usuario.Email);
            if (existente == null)
            { usuarios.Add(usuario); }
            else
            {
                List<Roles> roles = usuarios.Find(x => x.Email == usuario.Email).Roles.ToList();
                roles.Add(usuario.Roles[0]);
                usuarios.Find(x => x.Email == usuario.Email).Roles = roles.ToArray();
            }
            Archivos.Instancia.ModificarArchivoUsuarios(usuarios);
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
            EditarUsuario((Usuario)padre, Padres.Find(x => x.Id == id).Email, Roles.Padre);
            Padres.RemoveAll(x => x.Id == id);
            Padres.Add(padre);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado EditarDocente(int id, Docente docente)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            EditarUsuario((Usuario)docente, Docentes.Find(x => x.Id == id).Email, Roles.Docente);
            Docentes.RemoveAll(x => x.Id == id);
            Docentes.Add(docente);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado EditarDirectora(int id, Directora directora)
        {
            List<Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            EditarUsuario((Usuario)directora, Directoras.Find(x => x.Id == id).Email, Roles.Directora);
            Directoras.RemoveAll(x => x.Id == id);
            Directoras.Add(directora);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }

        private void EditarUsuario(Usuario usuario , string Email, Roles rol)
        {
            List<UsuarioLogin> lista = Archivos.Instancia.ObtenerUsuarios().ToList();
            lista.RemoveAll(x => x.Email == Email);
            lista.Add(ConvercionDeUsuario(usuario, rol));
            Archivos.Instancia.ModificarArchivoUsuarios(lista);
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
            EliminarUsuario((Usuario)Padres.Find(x => x.Id == id), Roles.Padre);
            Padres.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoPadres(Padres);
            return new Resultado();
        }

        public Resultado EliminarDocente(int id)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            EliminarUsuario((Usuario)Docentes.Find(x => x.Id == id), Roles.Docente);
            Docentes.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);
            return new Resultado();
        }

        public Resultado EliminarDirectora(int id)
        {
            List <Directora> Directoras = Archivos.Instancia.ObtenerDirectoras().ToList();
            EliminarUsuario((Usuario)Directoras.Find(x => x.Id == id), Roles.Directora);
            Directoras.RemoveAll(x => x.Id == id);
            Archivos.Instancia.ModificarArchivoDirectoras(Directoras);
            return new Resultado();
        }

        private void EliminarUsuario(Usuario usuario, Roles rol)
        {
            List<UsuarioLogin> lista = Archivos.Instancia.ObtenerUsuarios().ToList();
            UsuarioLogin ElUsuario = lista.Find(x => x.Email == ConvercionDeUsuario(usuario, rol).Email);
            if (ElUsuario.Roles.Count() > 1)
            { lista.Find(x => x == ElUsuario).Roles = ElUsuario.Roles.Where(x => x != rol).ToArray(); }
            else
            { lista.RemoveAll(x => x.Email == ConvercionDeUsuario(usuario, rol).Email); }            
            Archivos.Instancia.ModificarArchivoUsuarios(lista);
        }




        public Grilla<Hijo> ObtenerGrillaAlumnos(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            List<Hijo> hijos = Archivos.Instancia.ObtenerHijos();
            IQueryable<Hijo> Query = hijos.Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).AsQueryable();
            return new Grilla<Hijo>()
            {
                Lista = Query.Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Query.Count()
            };
        }

        public Grilla<Padre> ObtenerGrillaPadres(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            List<Padre> padres = Archivos.Instancia.ObtenerPadres();
            IQueryable<Padre> Query = padres.Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).AsQueryable();
            return new Grilla<Padre>()
            {
                Lista = Query.Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Query.Count()
            };
        }

        public Grilla<Docente> ObtenerGrillaDocentes(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            List<Docente> docentes = Archivos.Instancia.ObtenerDocentes();
            IQueryable<Docente> Query = docentes.Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).AsQueryable();
            return new Grilla<Docente>()
            {
                Lista = Query.Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Query.Count()
            };
        }

        public Grilla<Directora> ObtenerGrillaDirectoras(int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            List<Directora> directoras = Archivos.Instancia.ObtenerDirectoras();
            IQueryable<Directora> Query = directoras.Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal)).AsQueryable();
            return new Grilla<Directora>()
            {
                Lista = Query.Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = Archivos.Instancia.ObtenerDirectoras().ToList().Count
            };
        }




        private UsuarioLogin ConvercionDeUsuario(Usuario usuario , Roles rol)
        { return new UsuarioLogin(usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Email, (new Random().Next(1000000)).ToString(), rol); }

        private UsuarioLogueado ConvercionDeUsuario(UsuarioLogin usuario)
        { return new UsuarioLogueado() { Email = usuario.Email, Nombre = usuario.Nombre, Apellido = usuario.Apellido, Roles = usuario.Roles , RolSeleccionado = usuario.Roles[0] }; }




        public Sala[] ObtenerSalasPorInstitucion()
        { return Archivos.Instancia.ObtenerSalas().ToArray(); }

        public Resultado MarcarNotaComoLeida(Nota nota, UsuarioLogueado usuarioLogueado)
        {           
            List<Hijo> hijos = Archivos.Instancia.ObtenerHijos();
            Nota Nota = hijos.Find(x => x.Id == ObtenerPersonas(usuarioLogueado).ToList().Single(y => y.Notas.Contains(nota)).Id).Notas.Single(x => x.Id == nota.Id);
            Nota.Leida = true;
            Archivos.Instancia.ModificarArchivoHijos(hijos);
            return new Resultado();
        }

        public Resultado AsignarHijoPadre(Hijo hijo, Padre padre)
        {
            List<Padre> padres = Archivos.Instancia.ObtenerPadres().ToList();
            Padre PadreHijos = padres.Find(x => x.Id == padre.Id);
            List<Hijo> Hijos = PadreHijos.Hijos is null ? new List<Hijo>() : PadreHijos.Hijos.ToList();

            if (!Hijos.Any(x => x.Id == hijo.Id))
            { Hijos.Add(hijo); }
            PadreHijos.Hijos = Hijos.ToArray();
            Archivos.Instancia.ModificarArchivoPadres(padres);

            return new Resultado();
        }

        public Resultado DesasignarHijoPadre(Hijo hijo, Padre padre)
        {
            List<Padre> padres = Archivos.Instancia.ObtenerPadres();
            Padre PadreHijos = Archivos.Instancia.ObtenerPadres().Find(x => x.Id == padre.Id);
            List<Hijo> hijos = PadreHijos.Hijos.ToList();
            hijos.RemoveAll(x => x.Id == hijo.Id);
            PadreHijos.Hijos = hijos.ToArray();

            Archivos.Instancia.ModificarArchivoPadres(padres);

            return new Resultado();
        }

        public Resultado AsignarDocenteSala(Docente docente, Sala sala)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            Docente profesor = Docentes.Find(x => x.Id == docente.Id);
            List<Sala> Salas = profesor.Salas is null ? new List<Sala>() : profesor.Salas.ToList();
            if (!Salas.Any(x => x.Id == sala.Id))
            { Salas.Add(sala); }
            profesor.Salas = Salas.ToArray();
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);

            return new Resultado();
        }

        public Resultado DesasignarDocenteSala(Docente docente, Sala sala)
        {
            List<Docente> Docentes = Archivos.Instancia.ObtenerDocentes().ToList();
            Docente profesor = Docentes.Find(x => x.Id == docente.Id);
            List<Sala> salas = profesor.Salas.ToList();
            salas.RemoveAll(x => x.Id == sala.Id);
            profesor.Salas = salas.ToArray();
            Archivos.Instancia.ModificarArchivoDocentes(Docentes);

            return new Resultado();
        }

        public Resultado ResponderNota(Nota nota, Comentario nuevoComentario, UsuarioLogueado usuarioLogueado)
        {
            List<Hijo> hijos = Archivos.Instancia.ObtenerHijos();
            Nota LaNota = hijos.Find(x => x.Id == ObtenerPersonas(usuarioLogueado).ToList().Single(y => y.Notas.Contains(nota)).Id).Notas.Single(x => x.Id == nota.Id);
            LaNota.Comentarios[LaNota.Comentarios.Length] = nuevoComentario;
            Archivos.Instancia.ModificarArchivoHijos(hijos);
            return new Resultado();
        }

    }
}

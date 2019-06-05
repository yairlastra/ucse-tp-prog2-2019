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
    internal sealed class Archivos
    {
        public static Archivos Instancia { get { return new Archivos(); } }

        private static string UbicacionArchivo = @" C:\Users\lu_ga\Documents\ucse-tp-prog2-2019\WebApp\Archivos\";

        public static string RutaArchivoInstituciones = UbicacionArchivo + "Instituciones.txt";
        public static string RutaArchivoHijos = UbicacionArchivo + "Hijos.txt";
        public static string RutaArchivoPadres = UbicacionArchivo + "Padres.txt";
        public static string RutaArchivoDocentes = UbicacionArchivo + "Docentes.txt";
        public static string RutaArchivoDirectoras = UbicacionArchivo + "Directoras.txt";
         public static string RutaArchivoUsuarios = UbicacionArchivo + "Usuarios.txt";

        public List<Institucion> ObtenerInstituciones()
        {
            List <Institucion> Instituciones = new List<Institucion> { };
            if (!File.Exists(RutaArchivoInstituciones))
            { File.Create(RutaArchivoInstituciones); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoInstituciones, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Instituciones = JsonConvert.DeserializeObject<List<Institucion>>(ContenidoDelArchivo) == null ? new List<Institucion> { } : JsonConvert.DeserializeObject<List<Institucion>>(ContenidoDelArchivo);
                }
            }
            return Instituciones;
        }

        public List<Hijo> ObtenerHijos()
        {
            List<Hijo> Hijos = new List<Hijo> { };
            if (!File.Exists(RutaArchivoHijos))
            { File.Create(RutaArchivoHijos); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoHijos, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Hijos = JsonConvert.DeserializeObject<List<Hijo>>(ContenidoDelArchivo) == null ? new List<Hijo> { } : JsonConvert.DeserializeObject<List<Hijo>>(ContenidoDelArchivo);
                }
            }
            return Hijos;
        }

        public List<Padre> ObtenerPadres()
        {
            List<Padre> Padres = new List<Padre> { };
            if (!File.Exists(RutaArchivoPadres))
            { File.Create(RutaArchivoPadres); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoPadres, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Padres = JsonConvert.DeserializeObject<List<Padre>>(ContenidoDelArchivo) == null ? new List<Padre> { } : JsonConvert.DeserializeObject<List<Padre>>(ContenidoDelArchivo);
                }
            }
            return Padres;
        }

        public List<Docente> ObtenerDocentes()
        {
            List<Docente> Docentes = new List<Docente> { };
            if (!File.Exists(RutaArchivoDocentes))
            { File.Create(RutaArchivoDocentes); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoDocentes, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Docentes = JsonConvert.DeserializeObject<List<Docente>>(ContenidoDelArchivo) == null ? new List<Docente> { } : JsonConvert.DeserializeObject<List<Docente>>(ContenidoDelArchivo);
                }
            }
            return Docentes;
        }

        public List<Directora> ObtenerDirectoras()
        {
            List<Directora> Directoras = new List<Directora> { };
            if (!File.Exists(RutaArchivoDirectoras))
            { File.Create(RutaArchivoDirectoras); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoDirectoras, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Directoras = JsonConvert.DeserializeObject<List<Directora>>(ContenidoDelArchivo) == null ? new List<Directora> { } : JsonConvert.DeserializeObject<List<Directora>>(ContenidoDelArchivo);
                }
            }
            return Directoras;
        }

        public List<UsuarioLogin> ObtenerUsuarios()
        {
            List<UsuarioLogin> Usuarios = new List<UsuarioLogin> { };
            if (!File.Exists(RutaArchivoUsuarios))
            { File.Create(RutaArchivoUsuarios); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoUsuarios, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Usuarios = JsonConvert.DeserializeObject<List<UsuarioLogin>>(ContenidoDelArchivo) == null ? new List<UsuarioLogin> { } : JsonConvert.DeserializeObject<List<UsuarioLogin>>(ContenidoDelArchivo);
                }
            }
            return Usuarios;
        }

        public bool ModificarArchivoInstituciones(List<Institucion> Instituciones)
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoInstituciones, false))
            {
                string jsonInstituciones = JsonConvert.SerializeObject(Instituciones);
                Escribir.Write(jsonInstituciones);
                return true;
            }
        }

        public bool ModificarArchivoHijos(List<Hijo> Hijos)
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoHijos, false))
            {
                string jsonHijos = JsonConvert.SerializeObject(Hijos);
                Escribir.Write(jsonHijos);
                return true;
            }
        }

        public bool ModificarArchivoPadres(List<Padre> Padres)
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoPadres, false))
            {
                string jsonPadres = JsonConvert.SerializeObject(Padres);
                Escribir.Write(jsonPadres);
                return true;
            }
        }

        public bool ModificarArchivoDocentes(List<Docente> Docentes)
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoDocentes, false))
            {
                string jsonDocentes = JsonConvert.SerializeObject(Docentes);
                Escribir.Write(jsonDocentes);
                return true;
            }
        }

        public bool ModificarArchivoDirectoras(List<Directora> Directoras)
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoDirectoras, false))
            {
                string jsonDirectoras = JsonConvert.SerializeObject(Directoras);
                Escribir.Write(jsonDirectoras);
                return true;
            }
        }

        public bool ModificarArchivoUsuarios(List<UsuarioLogin> Usuarios)
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoDirectoras, false))
            {
                string jsonUsuarios = JsonConvert.SerializeObject(Usuarios);
                Escribir.Write(jsonUsuarios);
                return true;
            }
        }


    }
}

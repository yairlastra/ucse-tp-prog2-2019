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
        private readonly static Archivos instancia = new Archivos();

        public static Archivos Instancia { get { return instancia; } }

        private Archivos() {  }

            //if (!Directory.Exists(UbicacionArchivo)) { Directory.CreateDirectory(UbicacionArchivo); }

        private static readonly string UbicacionArchivo = @" C:\Users\lu_ga\Documents\ucse-tp-prog2-2019\WebApp\Archivos";

        private static string RutaArchivoInstituciones =UbicacionArchivo + @"\Instituciones.txt";
        private static string RutaArchivoHijos =UbicacionArchivo + @"\Hijos.txt";
        private static string RutaArchivoPadres = UbicacionArchivo + @"\Padres.txt";
        private static string RutaArchivoDocentes = UbicacionArchivo + @"\Docentes.txt";
        private static string RutaArchivoDirectoras = UbicacionArchivo + @"\Directoras.txt";
        private static string RutaArchivoUsuarios = UbicacionArchivo + @"\Usuarios.txt";     
            
            

        public List<Institucion> ObtenerInstituciones()
        {
            if (!File.Exists(RutaArchivoInstituciones)) { File.Create(RutaArchivoInstituciones); }
            List <Institucion> Instituciones = new List<Institucion> { };
                using (StreamReader Leer = new StreamReader(RutaArchivoInstituciones, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Instituciones = JsonConvert.DeserializeObject<List<Institucion>>(ContenidoDelArchivo) ?? new List<Institucion> { };
                }
            return Instituciones;
        }

        public List<Hijo> ObtenerHijos()
        {
            if (!File.Exists(RutaArchivoHijos)) { File.Create(RutaArchivoHijos); }
            List<Hijo> Hijos = new List<Hijo> { };
                using (StreamReader Leer = new StreamReader(RutaArchivoHijos, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Hijos = JsonConvert.DeserializeObject<List<Hijo>>(ContenidoDelArchivo) ?? new List<Hijo> { };
                }
            return Hijos;
        }

        public List<Padre> ObtenerPadres()
        {
            if (!File.Exists(RutaArchivoPadres)) { File.Create(RutaArchivoPadres); }
            List<Padre> Padres = new List<Padre> { };
            using (StreamReader Leer = new StreamReader(RutaArchivoPadres, true))
            {
                string ContenidoDelArchivo = Leer.ReadToEnd();
                Padres = JsonConvert.DeserializeObject<List<Padre>>(ContenidoDelArchivo) ?? new List<Padre> { };
            }
            return Padres;
        }

        public List<Docente> ObtenerDocentes()
        {
            if (!File.Exists(RutaArchivoDocentes)) { File.Create(RutaArchivoDocentes); }
            List<Docente> Docentes = new List<Docente> { };
            using (StreamReader Leer = new StreamReader(RutaArchivoDocentes, true))
            {
                string ContenidoDelArchivo = Leer.ReadToEnd();
                Docentes = JsonConvert.DeserializeObject<List<Docente>>(ContenidoDelArchivo) ?? new List<Docente> { };
            }

            return Docentes;
        }

        public List<Directora> ObtenerDirectoras()
        {
            if (!File.Exists(RutaArchivoDirectoras)) { File.Create(RutaArchivoDirectoras); }
            List<Directora> Directoras = new List<Directora> { };
            using (StreamReader Leer = new StreamReader(RutaArchivoDirectoras, true))
            {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Directoras = JsonConvert.DeserializeObject<List<Directora>>(ContenidoDelArchivo) ?? new List<Directora> { };
            }
            
            return Directoras;
        }

        public List<UsuarioLogin> ObtenerUsuarios()
        {
            if (!File.Exists(RutaArchivoUsuarios)) { File.Create(RutaArchivoUsuarios); }
            List<UsuarioLogin> Usuarios = new List<UsuarioLogin> { };
                using (StreamReader Leer = new StreamReader(RutaArchivoUsuarios, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Usuarios = JsonConvert.DeserializeObject<List<UsuarioLogin>>(ContenidoDelArchivo) ?? new List<UsuarioLogin> { };
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
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoUsuarios, false))
            {
                string jsonUsuarios = JsonConvert.SerializeObject(Usuarios);
                Escribir.Write(jsonUsuarios);
                return true;
            }
        }


    }
}

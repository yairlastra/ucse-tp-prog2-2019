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




        private static readonly string RutaArchivoInstituciones = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Instituciones.txt");
        private static readonly string RutaArchivoHijos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Hijos.txt");
        private static readonly string RutaArchivoPadres = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Padres.txt");
        private static readonly string RutaArchivoDocentes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Docentes.txt");
        private static readonly string RutaArchivoDirectoras = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Directoras.txt");
        private static readonly string RutaArchivoUsuarios = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios.txt");
        private static readonly string RutaArchivoSalas = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Salas.txt");




        public List<Institucion> ObtenerInstituciones()
        {
            List<Institucion> Instituciones = new List<Institucion> { };
            if (!File.Exists(RutaArchivoInstituciones))
            { File.Create(RutaArchivoInstituciones); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoInstituciones, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Instituciones = JsonConvert.DeserializeObject<List<Institucion>>(ContenidoDelArchivo);
                }
            }
            return Instituciones ?? new List<Institucion> { };
        }

        public List<Hijo> ObtenerHijos()
        {
            List<Hijo> Hijos = new List<Hijo> { };
            if (!File.Exists(RutaArchivoHijos))
            { File.Create(RutaArchivoHijos); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoHijos, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Hijos = JsonConvert.DeserializeObject<List<Hijo>>(ContenidoDelArchivo);
                }
            }
            return Hijos ?? new List<Hijo> { };
        }

        public List<Padre> ObtenerPadres()
        {
            List<Padre> Padres = new List<Padre> { };
            if (!File.Exists(RutaArchivoPadres))
            { File.Create(RutaArchivoPadres); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoPadres, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Padres = JsonConvert.DeserializeObject<List<Padre>>(ContenidoDelArchivo);
                }
            }
            return Padres ?? new List<Padre> { };
        }

        public List<Docente> ObtenerDocentes()
        {
            List<Docente> Docentes = new List<Docente> { };
            if (!File.Exists(RutaArchivoDocentes))
            { File.Create(RutaArchivoDocentes); }
            else
            { 
                using (StreamReader Leer = new StreamReader(RutaArchivoDocentes, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Docentes = JsonConvert.DeserializeObject<List<Docente>>(ContenidoDelArchivo);
                }  
            }
            return Docentes ?? new List<Docente> { };
        }

        public List<Directora> ObtenerDirectoras()
        {
            List<Directora> Directoras = new List<Directora> { };
            if (!File.Exists(RutaArchivoDirectoras))
            { File.Create(RutaArchivoDirectoras); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoDirectoras, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Directoras = JsonConvert.DeserializeObject<List<Directora>>(ContenidoDelArchivo);
                }
            }
            return Directoras ?? new List<Directora> { };
        }

        public List<UsuarioLogin> ObtenerUsuarios()
        {
            List<UsuarioLogin> Usuarios = new List<UsuarioLogin> { };
            if (!File.Exists(RutaArchivoUsuarios))
            { File.Create(RutaArchivoUsuarios); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoUsuarios, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Usuarios = JsonConvert.DeserializeObject<List<UsuarioLogin>>(ContenidoDelArchivo) ;
                }
            }
            return Usuarios ?? new List<UsuarioLogin> { };
        }

        public List<Sala> ObtenerSalas()
        {
            List<Sala> Salas = new List<Sala> { };
            if (!File.Exists(RutaArchivoSalas))
            { File.Create(RutaArchivoSalas); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoSalas, true))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Salas = JsonConvert.DeserializeObject<List<Sala>>(ContenidoDelArchivo);
                }
            }
            return Salas ?? new List<Sala> { };
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

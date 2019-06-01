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


        public static string RutaArchivoInstituciones  = @" C:\Users\lu_ga\Documents\prog1-tp-net-2018\trabajoPracticoNet\archivos\Instituciones.txt";
        public static string RutaArchivoHijos = @" C:\Users\lu_ga\Documents\prog1-tp-net-2018\trabajoPracticoNet\archivos\Hijos.txt";
        public static string RutaArchivoPadres = @" C:\Users\lu_ga\Documents\prog1-tp-net-2018\trabajoPracticoNet\archivos\Padres.txt";
        public static string RutaArchivoDocentes = @" C:\Users\lu_ga\Documents\prog1-tp-net-2018\trabajoPracticoNet\archivos\Docentes.txt";


        public Institucion[] ObtenerInstituciones()
        {
            Institucion[] Instituciones = new Institucion[] {};
            if (!File.Exists(RutaArchivoInstituciones))
            { File.Create(RutaArchivoInstituciones); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoInstituciones, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Instituciones = JsonConvert.DeserializeObject<Institucion[]>(ContenidoDelArchivo) == null ? new Institucion[]{} : JsonConvert.DeserializeObject<Institucion[]>(ContenidoDelArchivo);
                }
            }
            return Instituciones;
        }

        public Hijo[] ObtenerHijos()
        {
            Hijo[] Hijos = new Hijo[] {};
            if (!File.Exists(RutaArchivoHijos))
            { File.Create(RutaArchivoHijos); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoHijos, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Hijos = JsonConvert.DeserializeObject<Hijo[]>(ContenidoDelArchivo) == null ? new Hijo[] { } : JsonConvert.DeserializeObject<Hijo[]>(ContenidoDelArchivo);
                }
            }
            return Hijos;
        }

        public Padre[] ObtenerPadres()
        {
            Padre[] Padres = new Padre[] {};
            if (!File.Exists(RutaArchivoPadres))
            { File.Create(RutaArchivoPadres); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoPadres, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Padres = JsonConvert.DeserializeObject<Padre[]>(ContenidoDelArchivo) == null ? new Padre[] { } : JsonConvert.DeserializeObject<Padre[]>(ContenidoDelArchivo);
                }
            }
            return Padres;
        }

        public Docente[] ObtenerDocentes()
        {
            Docente[] Docentes = new Docente[] {};
            if (!File.Exists(RutaArchivoDocentes))
            { File.Create(RutaArchivoDocentes); }
            else
            {
                using (StreamReader Leer = new StreamReader(RutaArchivoDocentes, false))
                {
                    string ContenidoDelArchivo = Leer.ReadToEnd();
                    Docentes = JsonConvert.DeserializeObject<Docente[]>(ContenidoDelArchivo) == null ? new Docente[] { } : JsonConvert.DeserializeObject<Docente[]>(ContenidoDelArchivo);
                }
            }
            return Docentes;
        }

        public bool ModificarArchivoInstituciones()
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoInstituciones, false))
            {
                string jsonInstituciones = JsonConvert.SerializeObject(ObtenerInstituciones());
                Escribir.Write(jsonInstituciones);
                return true;
            }
        }

        public bool ModificarArchivoHijos()
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoHijos, false))
            {
                string jsonHijos = JsonConvert.SerializeObject(ObtenerHijos());
                Escribir.Write(jsonHijos);
                return true;
            }
        }

        public bool ModificarArchivoPadres()
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoPadres, false))
            {
                string jsonPadres = JsonConvert.SerializeObject(ObtenerPadres());
                Escribir.Write(jsonPadres);
                return true;
            }
        }

        public bool ModificarArchivoDocentes()
        {
            using (StreamWriter Escribir = new StreamWriter(RutaArchivoDocentes, false))
            {
                string jsonDocentes = JsonConvert.SerializeObject(ObtenerDocentes());
                Escribir.Write(jsonDocentes);
                return true;
            }
        }



    }
}

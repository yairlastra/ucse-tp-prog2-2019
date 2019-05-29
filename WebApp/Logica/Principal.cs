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
        private static Principal instancia = null;

        public static Principal Instancia
        {
            get
            {
                if (instancia == null)
                { instancia = new Principal(); }
                return instancia;
            }
        }

        private Principal()
        {
            this.Instituciones = new Institucion[]{};

        }

        public static string RutaArchivoInstituciones  = @" C:\Users\lu_ga\Documents\prog1-tp-net-2018\trabajoPracticoNet\archivos\Instituciones.txt";
           

        public Institucion[] Instituciones { get; set; }
        public Hijo[] Hijos { get; set; }
        public Padre[] Padres { get; set; }
        public Docente[] Docentes { get; set; }
        public Usuario[] Usuarios { get; set; }

        public Institucion[] ObtenerInstituciones()
        {
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




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public interface IServicioWeb
    {
        string ObtenerNombreGrupo();

        UsuarioLogueado ObtenerUsuario(string email, string clave);

        Institucion[] ObtenerInstituciones();

        Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado);

        Resultado EditarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado);

        Resultado EliminarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado);

        Sala[] ObtenerSalasPorInstitucion();

        Resultado AltaDocente(Docente docente, UsuarioLogueado usuarioLogueado);

        Resultado EditarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado);

        Resultado EliminarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado);

        Resultado AltaPadreMadre(Padre padre, UsuarioLogueado usuarioLogueado);

        Resultado EditarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado);

        Resultado EliminarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado);
    }
}

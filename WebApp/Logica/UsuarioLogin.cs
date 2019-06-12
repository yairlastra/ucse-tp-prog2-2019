using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;

namespace Logica
{
    public class UsuarioLogin : Usuario
    {
        public string Clave { get; set; }
        public Roles[] Roles { get; set; }

        public UsuarioLogin(int Id, string Nombre, string Apellido, string Email, string Clave, Roles rol)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Email = Email;
            this.Clave = Clave;
            this.Roles = new Roles[] { rol };
        }

    }
}

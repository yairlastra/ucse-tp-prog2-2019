namespace Contratos
{
    public enum Roles
    {
        Padre, Directora, Docente
    }

    public class UsuarioLogueado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Roles[] Roles { get; set; }
        
        public Roles RolSeleccionado { get; set; }
    }
}
namespace SIGPA.Models
{
    public class RolUsuario
    {
        public required int IdRolUsuario { get; set; }
        public required string NombreRolUsuario { get; set; }
        public required Usuario Usuario { get; set; }
    }
}

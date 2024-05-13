namespace SIGPA.Models
{
    public class AuthRequest
    {
        public string? EmailUsuario { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Username { get; set; }
        public required string Password { get; set; }
    }
}

namespace SIGPA.Models
{

   public class AuthResponse(Usuario usuario, string Token)
        {
          public int IdUsuario { get; set; } = usuario.IdUsuario;
          public string Token { get; set; } = Token;
          public string EmailUsuario { get; set; } = usuario.EmailUsuario;
          public string? Username { get; set; } = usuario.Username;
          public string NombresUsuario { get; set; } = usuario.NombresUsuario;
         public string ApellidosUsuario { get; set; } = usuario.ApellidosUsuario;
   }
}

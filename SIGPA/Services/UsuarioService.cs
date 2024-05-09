using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IUsuarioService
    {
        Task<AuthResponse?> Authenticate(AuthRequest authRequest);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario?> GetUsuario(int id);
        Task<Usuario> CreateUsuario(
          string NombresUsuario,
          string ApellidosUsuario,
          string EmailUsuario,
          string? Username,
          string Password,
          int IdRolUsuario
        );
        Task<Usuario> UpdateUsuario(
          int IdUsuario,
          string? NombresUsuario,
          string? ApellidosUsuario,
          string? EmailUsuario,
          string? Username,
          string? Password,
          int? IdRolUsuario
      );
        Task<Usuario?> DeleteUsuario(int id);
    }
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        public async Task<AuthResponse?> Authenticate(AuthRequest authRequest)
        {
            return await usuarioRepository.Authenticate(authRequest);
        }
        public async Task<Usuario?> GetUsuario(int id)
        {
            return await usuarioRepository.GetUsuario(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await usuarioRepository.GetUsuarios();
        }

        public async Task<Usuario> CreateUsuario(
          string NombresUsuario,
          string ApellidosUsuario,
          string EmailUsuario,
          string? Username,
          string Password,
          int IdRolUsuario
                     )
        {
            return await usuarioRepository.CreateUsuario(new Usuario
            {
                NombresUsuario = NombresUsuario,
                ApellidosUsuario = ApellidosUsuario,
                EmailUsuario = EmailUsuario,
                Username = Username,
                Password = Password,
                IdRolUsuario = IdRolUsuario
            });
        }

        public async Task<Usuario> UpdateUsuario(
            int IdUsuario,
            string? NombresUsuario,
            string? ApellidosUsuario,
            string? EmailUsuario,
            string? Username,
            string? Password,
            int? IdRolUsuario
         )
        {
            Usuario? usuario = await usuarioRepository.GetUsuario(IdUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            usuario.NombresUsuario = NombresUsuario ?? usuario.NombresUsuario;
            usuario.ApellidosUsuario = ApellidosUsuario ?? usuario.ApellidosUsuario;
            usuario.EmailUsuario = EmailUsuario ?? usuario.EmailUsuario;
            usuario.Username = Username ?? usuario.Username;
            usuario.Password = Password ?? usuario.Password;
            usuario.IdRolUsuario = IdRolUsuario ?? usuario.IdRolUsuario;
            return await usuarioRepository.UpdateUsuario(usuario);
        }

        public async Task<Usuario?> DeleteUsuario(int id)
        {
           return await usuarioRepository.DeleteUsuario(id);
        }
    }
}

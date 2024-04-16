using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetUsuario(int IdUsuario);
        Task<Usuario> CreateUsuario(string NombreUsuario, string EmailUsuario, int IdRolUsuario);
        Task<Usuario> UpdateUsuario(
          int IdUsuario,
          string? NombreUsuario = null,
          string? EmailUsuario = null,
           int? IdRolUsuario = null
       );
        Task<Usuario> DeleteUsuario(int IdUsuario);
    }
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<Usuario> GetUsuario(int IdUsuario)
        {
            return await _usuarioRepository.GetUsuario(IdUsuario);
        }

        public async Task<Usuario> CreateUsuario(string NombreUsuario, string EmailUsuario, int IdRolUsuario)
        {
            return await _usuarioRepository.CreateUsuario(NombreUsuario, EmailUsuario, IdRolUsuario);
        }

        public async Task<Usuario> UpdateUsuario(
           int IdUsuario,
           string? NombreUsuario = null,
           string? EmailUsuario = null,
          int? IdRolUsuario = null
                              )
        {
            var usuario = await _usuarioRepository.GetUsuario(IdUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuario not found");
            }

            if (NombreUsuario != null)
            {
                usuario.NombreUsuario = NombreUsuario;
            }
            if (EmailUsuario != null)
            {
                usuario.EmailUsuario = EmailUsuario;
            }
            if (IdRolUsuario != null)
            {
                usuario.IdRolUsuario = (int)IdRolUsuario;
            }

            return await _usuarioRepository.UpdateUsuario(usuario);
        }

        public async Task<Usuario> DeleteUsuario(int IdUsuario)
        {
            return await _usuarioRepository.DeleteUsuario(IdUsuario);
        }
    }
}

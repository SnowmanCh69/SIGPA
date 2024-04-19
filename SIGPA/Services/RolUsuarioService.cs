using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IRolUsuarioService
    {
        Task<IEnumerable<RolUsuario>> GetRolesUsuarios();
        Task<RolUsuario?> GetRolUsuario(int id);
        Task<RolUsuario> CreateRolUsuario(
         string nombreRolUsuario
        );
        Task<RolUsuario> UpdateRolUsuario(
            int IdRolUsuario,
            string? nombreRolUsuario
        );
        Task<RolUsuario?> DeleteRolUsuario(int id);

    }
    public class RolUsuarioService(IRolUsuarioRepository rolUsuarioRepository) : IRolUsuarioService
    {
        public async Task<RolUsuario?> GetRolUsuario(int id)
        {
            return await rolUsuarioRepository.GetRolUsuario(id);
        }

        public async Task<IEnumerable<RolUsuario>> GetRolesUsuarios()
        {
            return await rolUsuarioRepository.GetRolesUsuarios();
        }

        public async Task<RolUsuario> CreateRolUsuario(
            string nombreRolUsuario
         )
        {
          return await rolUsuarioRepository.CreateRolUsuario(new RolUsuario 
          { 
              NombreRolUsuario = nombreRolUsuario
          });
         
        }

        public async Task<RolUsuario> UpdateRolUsuario(
           
            int IdRolUsuario,
            string? nombreRolUsuario
           )
        {
            RolUsuario? rolUsuario = await rolUsuarioRepository.GetRolUsuario(IdRolUsuario);
            if (rolUsuario == null) throw new Exception("RolUsuario no encontrado");

            rolUsuario.NombreRolUsuario = nombreRolUsuario ?? rolUsuario.NombreRolUsuario;

            return await rolUsuarioRepository.UpdateRolUsuario(rolUsuario);
        }

        public async Task<RolUsuario?> DeleteRolUsuario(int id)
        {
            return await rolUsuarioRepository.DeleteRolUsuario(id);
        }
    }
    
}

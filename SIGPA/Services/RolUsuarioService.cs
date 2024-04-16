using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services

{ 
    public interface IRolUsuarioService
    {
        Task<List<RolUsuario>> GetAll();
        Task<RolUsuario> GetRolUsuario(int IdRolUsuario);
        Task<RolUsuario> CreateRolUsuario(string NombreRolUsuario);
        Task<RolUsuario> UpdateRolUsuario(
          int IdRolUsuario,
          string? NombreRolUsuario = null
        );
        Task<RolUsuario> DeleteRolUsuario(int IdRolUsuario);
    }


    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _rolUsuarioRepository;
        public RolUsuarioService(IRolUsuarioRepository rolUsuarioRepository)
        {
            _rolUsuarioRepository = rolUsuarioRepository;
        }

        public async Task<List<RolUsuario>> GetAll()
        {
            return await _rolUsuarioRepository.GetAll();
        }

        public async Task<RolUsuario> GetRolUsuario(int IdRolUsuario)
        {
            return await _rolUsuarioRepository.GetRolUsuario(IdRolUsuario);
        }

        public async Task<RolUsuario> CreateRolUsuario(string NombreRolUsuario)
        {
            return await _rolUsuarioRepository.CreateRolUsuario(NombreRolUsuario);
        }

        public async Task<RolUsuario> UpdateRolUsuario(
                      int IdRolUsuario,
                                 string? NombreRolUsuario = null
                              )
        {
            var rolUsuario = await _rolUsuarioRepository.GetRolUsuario(IdRolUsuario);
            if (rolUsuario == null)
            {
                throw new Exception("RolUsuario not found");
            }

            if (NombreRolUsuario != null)
            {
                rolUsuario.NombreRolUsuario = NombreRolUsuario;
            }

            return await _rolUsuarioRepository.UpdateRolUsuario(rolUsuario);
        }

        public async Task<RolUsuario> DeleteRolUsuario(int IdRolUsuario)
        {
            return await _rolUsuarioRepository.DeleteRolUsuario(IdRolUsuario);
        }
    }
    
}

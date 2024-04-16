using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IRolUsuarioRepository
    {
        Task<List<RolUsuario>> GetAll();
        Task<RolUsuario?> GetRolUsuario(int id);
        Task<RolUsuario> CreateRolUsuario(string nombreRolUsuario);
        Task<RolUsuario> UpdateRolUsuario(RolUsuario rolUsuario);
        Task<RolUsuario> DeleteRolUsuario(int id);
    }
    public class RolUsuarioRepository : IRolUsuarioRepository
    {
        private readonly ApplicationDbContext _db;
        public RolUsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<RolUsuario>> GetAll()
        {
            return await _db.RolUsuarios.ToListAsync();
        }
        public async Task<RolUsuario?> GetRolUsuario(int id)
        {
            return await _db.RolUsuarios.FirstOrDefaultAsync(e => e.IdRolUsuario == id);
        }
        public async Task<RolUsuario> CreateRolUsuario(string nombreRolUsuario)
        {
            RolUsuario newRolUsuario = new RolUsuario
            {
                NombreRolUsuario = nombreRolUsuario
            };
            await _db.RolUsuarios.AddAsync(newRolUsuario);
            await _db.SaveChangesAsync();
            return newRolUsuario;
        }
        public async Task<RolUsuario> UpdateRolUsuario(RolUsuario rolUsuario)
        {
            _db.RolUsuarios.Update(rolUsuario);
            await _db.SaveChangesAsync();
            return rolUsuario;
        }
        public async Task<RolUsuario> DeleteRolUsuario(int id)
        {
            RolUsuario rolUsuario = await GetRolUsuario(id);

            return rolUsuario;
        }
    }
}

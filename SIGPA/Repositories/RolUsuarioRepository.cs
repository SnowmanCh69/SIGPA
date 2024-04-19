using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IRolUsuarioRepository
    {
        Task<IEnumerable<RolUsuario>> GetRolesUsuarios();
        Task<RolUsuario?> GetRolUsuario(int id);
        Task<RolUsuario> CreateRolUsuario(RolUsuario rolUsuario);
        Task<RolUsuario> UpdateRolUsuario(RolUsuario rolUsuario);
        Task<RolUsuario?> DeleteRolUsuario(int id);

    }
    public class RolUsuarioRepository(ApplicationDbContext db) : IRolUsuarioRepository
    {

        public async Task<RolUsuario?> GetRolUsuario(int id)
        {
            return await db.RolUsuarios.FindAsync(id);
        }

        public async Task<IEnumerable<RolUsuario>> GetRolesUsuarios()
        {
            return await db.RolUsuarios.ToListAsync();
        }

        public async Task<RolUsuario> CreateRolUsuario(RolUsuario rolUsuario)
        {
            db.RolUsuarios.Add(rolUsuario);
            await db.SaveChangesAsync();
            return rolUsuario;
        }

        public async Task<RolUsuario> UpdateRolUsuario(RolUsuario rolUsuario)
        {
            db.Entry(rolUsuario).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return rolUsuario;
        }

        public async Task<RolUsuario?> DeleteRolUsuario(int id)
        {
            var rolUsuario = await db.RolUsuarios.FindAsync(id);
            if (rolUsuario == null) return rolUsuario;
            rolUsuario.IsDeleted = false;
            await db.SaveChangesAsync();
            return rolUsuario;
        }
    }
}

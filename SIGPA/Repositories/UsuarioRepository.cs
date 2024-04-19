using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{

    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario> DeleteUsuario(int id);
    }
    public class UsuarioRepository(ApplicationDbContext db) : IUsuarioRepository
    {

        public async Task<Usuario?> GetUsuario(int id)
        {
            return await db.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteUsuario(int id)
        {
            var usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null) return usuario;
            usuario.IsDeleted = false;
            await db.SaveChangesAsync();
            return usuario;
        }
    }
    
}

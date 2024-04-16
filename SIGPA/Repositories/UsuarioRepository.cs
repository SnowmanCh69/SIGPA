using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario?> GetUsuario(int id);
        Task<Usuario> CreateUsuario(string nombreUsuario, string emailUsuario, int idRolUsuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario> DeleteUsuario(int id);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;
        public UsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Usuario>> GetAll()
        {
            return await _db.Usuarios.ToListAsync();
        }
        public async Task<Usuario?> GetUsuario(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(e => e.IdUsuario == id);
        }
        public async Task<Usuario> CreateUsuario(string nombreUsuario, string emailUsuario, int idRolUsuario)
        {
            // Obtener el rol de usuario correspondiente a partir de su ID
            var rolUsuario = await _db.RolUsuarios.FindAsync(idRolUsuario);

            if (rolUsuario == null)
            {
                // Manejar la situación en la que el rol de usuario no existe
                throw new Exception("Rol de Usuario no encontrado");
            }

            // Crear una nueva instancia de Usuario con los valores proporcionados
            Usuario newUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                EmailUsuario = emailUsuario,
                IdRolUsuario = idRolUsuario,
                RolUsuario = rolUsuario
            };
            await _db.Usuarios.AddAsync(newUsuario);
            await _db.SaveChangesAsync();
            return newUsuario;
        }
        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            await _db.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> DeleteUsuario(int id)
        {
            Usuario usuario = await GetUsuario(id);

            return usuario;
        }
    }
}

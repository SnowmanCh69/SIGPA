using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SIGPA.Context;
using SIGPA.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGPA.Repositories
{

    public interface IUsuarioRepository
    {
        Task<AuthResponse?> Authenticate(AuthRequest authRequest); 
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario?> GetUsuario(int id);
        Task<Usuario?> GetUsuario(string? username= null, string? email = null);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario?> DeleteUsuario(int id);
    }
    public class UsuarioRepository(IOptions<AuthSettings> authSettings, ApplicationDbContext db, IRolUsuarioRepository rolUsuarioRepository) : IUsuarioRepository
    {
        private readonly AuthSettings authSettings = authSettings.Value;



        public async Task<AuthResponse?> Authenticate(AuthRequest authRequest)
        {
            // Check for username or email
            Usuario? usuario = await db.Usuarios.FirstOrDefaultAsync(u =>
                (u.Username == authRequest.Username || u.EmailUsuario == authRequest.EmailUsuario)
                && u.Password == authRequest.Password);

            if (usuario == null) return null;

            // Generate JWT
            string token = await GenerateJwtToken(usuario);

            return new AuthResponse(usuario, token);
        }


        // helper methods
        // Genera un token JWT para autenticación y autorización de usuarios.
        private async Task<string> GenerateJwtToken(Usuario usuario )
        {
            RolUsuario? rolUsuario = await rolUsuarioRepository.GetRolUsuario(usuario.IdRolUsuario);

            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                byte[] key = Encoding.ASCII.GetBytes(authSettings.Secret);
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.IdUsuario.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(rolUsuario?.NombreRolUsuario == "Jugador" ? 28 : 7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

        // CRUD
        public async Task<Usuario?> GetUsuario(int id)
        {
            return await db.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await db.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetUsuario(string? username = null, string? email = null)
        {
            if (username != null)
                return await db.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
            if (email != null)
                return await db.Usuarios.FirstOrDefaultAsync(u => u.EmailUsuario == email);
            return null;
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

        public async Task<Usuario?> DeleteUsuario(int id)
        {
            Usuario? usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null) return usuario;
            usuario.IsDeleted = false;
            db.Entry(usuario).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return usuario;
        }
    }
    
}

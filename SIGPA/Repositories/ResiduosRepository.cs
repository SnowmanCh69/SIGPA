using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IResiduosRepository
    {
        Task<List<Residuos>> GetAll();
        Task<Residuos?> GetResiduos(int id);
        Task<Residuos> CreateResiduos(DateTime fechaRegistro, int idEstadoResiduos, string cantidadRegistrada, int idTipoResiduos, int idUsuario, int idResiduosPartida);
        Task<Residuos> UpdateResiduos(Residuos residuos);
        Task<Residuos> DeleteResiduos(int id);
    }
    public class ResiduosRepository : IResiduosRepository
    {
        private readonly ApplicationDbContext _db;
        public ResiduosRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Residuos>> GetAll()
        {
            return await _db.Residuos.ToListAsync();
        }
        public async Task<Residuos?> GetResiduos(int id)
        {
            return await _db.Residuos.FirstOrDefaultAsync(e => e.IdResiduos == id);
        }
        public async Task<Residuos> CreateResiduos(DateTime fechaRegistro, int idEstadoResiduos, string cantidadRegistrada, int idTipoResiduos, int idUsuario, int idResiduosPartida)
        {
            // Obtener el estado de residuos, el tipo de residuos, el usuario y la relación ResiduosPartida correspondientes a partir de sus IDs
            var estadoResiduos = await _db.EstadoResiduos.FindAsync(idEstadoResiduos);
            var tipoResiduos = await _db.TipoResiduos.FindAsync(idTipoResiduos);
            var usuario = await _db.Usuarios.FindAsync(idUsuario);
            var residuosPartida = await _db.ResiduosPartida.FindAsync(idResiduosPartida);

            if (estadoResiduos == null || tipoResiduos == null || usuario == null || residuosPartida == null)
            {
                // Manejar la situación en la que el estado de residuos, el tipo de residuos, el usuario o la relación ResiduosPartida no existen
                throw new Exception("Estado de Residuos, Tipo de Residuos, Usuario o ResiduosPartida no encontrado");
            }

            // Crear una nueva instancia de Residuos con los valores proporcionados
            Residuos newResiduos = new Residuos
            {
                FechaRegistro = fechaRegistro,
                IdEstadoResiduos = idEstadoResiduos,
                CantidadRegistrada = cantidadRegistrada,
                IdTipoResiduos = idTipoResiduos,
                IdUsuario = idUsuario,
                IdResiduosPartida = idResiduosPartida,
                EstadoResiduos = estadoResiduos,
                TipoResiduos = tipoResiduos,
                Usuario = usuario,
                ResiduosPartida = residuosPartida
            };
            await _db.Residuos.AddAsync(newResiduos);
            await _db.SaveChangesAsync();
            return newResiduos;
        }
        public async Task<Residuos> UpdateResiduos(Residuos residuos)
        {
            _db.Residuos.Update(residuos);
            await _db.SaveChangesAsync();
            return residuos;
        }
        public async Task<Residuos> DeleteResiduos(int id)
        {
            Residuos residuos = await GetResiduos(id);

            return residuos;
        }
    }
}

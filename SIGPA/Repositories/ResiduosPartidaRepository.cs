using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IResiduosPartidaRepository
    {
        Task<List<ResiduosPartida>> GetAll();
        Task<ResiduosPartida?> GetResiduosPartida(int id);
        Task<ResiduosPartida> CreateResiduosPartida(int idPartida, int idResiduos, string cantidadRegistrada);
        Task<ResiduosPartida> UpdateResiduosPartida(ResiduosPartida residuosPartida);
        Task<ResiduosPartida> DeleteResiduosPartida(int id);
    }
    public class ResiduosPartidaRepository : IResiduosPartidaRepository
    {
        private readonly ApplicationDbContext _db;
        public ResiduosPartidaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<ResiduosPartida>> GetAll()
        {
            return await _db.ResiduosPartida.ToListAsync();
        }
        public async Task<ResiduosPartida?> GetResiduosPartida(int id)
        {
            return await _db.ResiduosPartida.FirstOrDefaultAsync(e => e.IdResiduosPartida == id);
        }
        public async Task<ResiduosPartida> CreateResiduosPartida(int idPartida, int idResiduos, string cantidadRegistrada)
        {
            // Obtener la partida y los residuos correspondientes a partir de sus IDs
            var partida = await _db.Partida.FindAsync(idPartida);
            var residuos = await _db.Residuos.FindAsync(idResiduos);

            if (partida == null || residuos == null)
            {
                // Manejar la situación en la que la partida o los residuos no existen
                throw new Exception("Partida o Residuos no encontrado");
            }

            // Crear una nueva instancia de ResiduosPartida con los valores proporcionados
            ResiduosPartida newResiduosPartida = new ResiduosPartida
            {
                IdPartida = idPartida,
                IdResiduos = idResiduos,
                CantidadRegistrada = cantidadRegistrada,
                Partida = partida,
                Residuos = residuos
            };
            await _db.ResiduosPartida.AddAsync(newResiduosPartida);
            await _db.SaveChangesAsync();
            return newResiduosPartida;
        }
        public async Task<ResiduosPartida> UpdateResiduosPartida(ResiduosPartida residuosPartida)
        {
            _db.ResiduosPartida.Update(residuosPartida);
            await _db.SaveChangesAsync();
            return residuosPartida;
        }
        public async Task<ResiduosPartida> DeleteResiduosPartida(int id)
        {
            ResiduosPartida residuosPartida = await GetResiduosPartida(id);

            return residuosPartida;
        }
    }
}

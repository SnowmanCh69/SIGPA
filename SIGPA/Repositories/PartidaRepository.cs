using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IPartidaRepository
    {
        Task<IEnumerable<Partida>> GetPartidas();
        Task<Partida?> GetPartida(int id);
        Task<Partida> CreatePartida(Partida partida);
        Task<Partida> UpdatePartida(Partida partida);
        Task<Partida?> DeletePartida(int id);
    }
    public class PartidaRepository(ApplicationDbContext db) : IPartidaRepository 
    {

        public async Task<Partida?> GetPartida(int id)
        {
            return await db.Partida.FindAsync(id);
        }

        public async Task<IEnumerable<Partida>> GetPartidas()
        {
            return await db.Partida.ToListAsync();
        }

        public async Task<Partida> CreatePartida(Partida partida)
        {
            db.Partida.Add(partida);
            await db.SaveChangesAsync();
            return partida;
        }

        public async Task<Partida> UpdatePartida(Partida partida)
        {
            db.Entry(partida).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return partida;
        }

        public async Task<Partida?> DeletePartida(int id)
        {
            Partida? partida = await db.Partida.FindAsync(id);
            if (partida == null) return partida;
            partida.IsNotDeleted = false;
            db.Entry(partida).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return partida;
        }

    }
}

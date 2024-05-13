using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;


    public interface IResiduosPartidaRepository
    {
        Task<IEnumerable<ResiduosPartida>> GetResiduosPartida();
        Task<ResiduosPartida?> GetResiduoPartida(int id);
        Task<ResiduosPartida> CreateResiduoPartida(ResiduosPartida residuoPartida);
        Task<ResiduosPartida> UpdateResiduoPartida(ResiduosPartida residuoPartida);
        Task<ResiduosPartida?> DeleteResiduoPartida(int id);
    }
    public class ResiduosPartidaRepository(ApplicationDbContext db): IResiduosPartidaRepository
    {
        public async Task<ResiduosPartida?> GetResiduoPartida(int id)
        {
            return await db.ResiduosPartida.FindAsync(id);
        }

        public async Task<IEnumerable<ResiduosPartida>> GetResiduosPartida()
        {
            return await db.ResiduosPartida.ToListAsync();
        }

        public async Task<ResiduosPartida> CreateResiduoPartida(ResiduosPartida residuoPartida)
        {
            db.ResiduosPartida.Add(residuoPartida);
            await db.SaveChangesAsync();
            return residuoPartida;
        }

        public async Task<ResiduosPartida> UpdateResiduoPartida(ResiduosPartida residuoPartida)
        {
            db.Entry(residuoPartida).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return residuoPartida;
        }

        public async Task<ResiduosPartida?> DeleteResiduoPartida(int id)
        {
            ResiduosPartida? residuoPartida = await db.ResiduosPartida.FindAsync(id);
            if (residuoPartida == null) return residuoPartida;
            residuoPartida.IsNotDeleted = false;
            db.Entry(residuoPartida).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return residuoPartida;
        }
    }
    


using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;


    public interface IRecolectaResiduosRepository
    {
        Task<IEnumerable<RecolectaResiduos>> GetRecolectasResiduos();
        Task<RecolectaResiduos?> GetRecolectaResiduos(int id);
        Task<RecolectaResiduos> CreateRecolectaResiduos(RecolectaResiduos recolectaResiduos);
        Task<RecolectaResiduos> UpdateRecolectaResiduos(RecolectaResiduos recolectaResiduos);
        Task<RecolectaResiduos?> DeleteRecolectaResiduos(int id);

    }
    public class RecolectaResiduosRepository(ApplicationDbContext db): IRecolectaResiduosRepository
    {
        public async Task<RecolectaResiduos?> GetRecolectaResiduos(int id)
        {
            return await db.RecolectaResiduos.FindAsync(id);
        }
        
        public async Task<IEnumerable<RecolectaResiduos>> GetRecolectasResiduos()
        {
            return await db.RecolectaResiduos.ToListAsync();
        }

        public async Task<RecolectaResiduos> CreateRecolectaResiduos(RecolectaResiduos recolectaResiduos)
        {
            db.RecolectaResiduos.Add(recolectaResiduos);
            await db.SaveChangesAsync();
            return recolectaResiduos;
        }
        public async Task<RecolectaResiduos> UpdateRecolectaResiduos(RecolectaResiduos recolectaResiduos)
        {
            db.Entry(recolectaResiduos).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return recolectaResiduos;
         }
        public async Task<RecolectaResiduos?> DeleteRecolectaResiduos(int id)
        {
            RecolectaResiduos? recolectaResiduos = await db.RecolectaResiduos.FindAsync(id);
            if (recolectaResiduos == null) return recolectaResiduos;
            recolectaResiduos.IsDeleted = false;
            db.Entry(recolectaResiduos).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return recolectaResiduos;
        }
    }


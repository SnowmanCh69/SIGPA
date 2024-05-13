using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IResiduosRepository
    {
        Task<IEnumerable<Residuos>> GetResiduos();
        Task<Residuos?> GetResiduo(int id);
        Task<Residuos> CreateResiduo(Residuos residuo);
        Task<Residuos> UpdateResiduo(Residuos residuo);
        Task<Residuos?> DeleteResiduo(int id);
    }
    public class ResiduosRepository(ApplicationDbContext db): IResiduosRepository
    {
        public async Task<Residuos?> GetResiduo(int id)
        {
            return await db.Residuos.FindAsync(id);
        }

        public async Task<IEnumerable<Residuos>> GetResiduos()
        {
            return await db.Residuos.ToListAsync();
        }

        public async Task<Residuos> CreateResiduo(Residuos residuo)
        {
            db.Residuos.Add(residuo);
            await db.SaveChangesAsync();
            return residuo;
        }

        public async Task<Residuos> UpdateResiduo(Residuos residuo)
        {
            db.Entry(residuo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return residuo;
        }

        public async Task<Residuos?> DeleteResiduo(int id)
        {
            Residuos? residuo = await db.Residuos.FindAsync(id);
            if (residuo == null) return residuo;
            residuo.IsNotDeleted = false;
            db.Entry(residuo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return residuo;

        }
    }
}

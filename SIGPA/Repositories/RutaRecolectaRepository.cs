using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IRutaRecolectaRepository
    {
        Task<IEnumerable<RutaRecolecta>> GetRutasRecolecta();
        Task<RutaRecolecta?> GetRutaRecolecta(int id);
        Task<RutaRecolecta> CreateRutaRecolecta(RutaRecolecta rutaRecolecta);
        Task<RutaRecolecta> UpdateRutaRecolecta(RutaRecolecta rutaRecolecta);
        Task<RutaRecolecta?> DeleteRutaRecolecta(int id);

    }
    public class RutaRecolectaRepository(ApplicationDbContext db): IRutaRecolectaRepository
    {
        public async Task<RutaRecolecta?> GetRutaRecolecta(int id)
        {
            return await db.RutaRecolecta.FindAsync(id);
        }

        public async Task<IEnumerable<RutaRecolecta>> GetRutasRecolecta()
        {
            return await db.RutaRecolecta.ToListAsync();
        }

        public async Task<RutaRecolecta> CreateRutaRecolecta(RutaRecolecta rutaRecolecta)
        {
            db.RutaRecolecta.Add(rutaRecolecta);
            await db.SaveChangesAsync();
            return rutaRecolecta;
        }

        public async Task<RutaRecolecta> UpdateRutaRecolecta(RutaRecolecta rutaRecolecta)
        {
            db.Entry(rutaRecolecta).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return rutaRecolecta;
        }

        public async Task<RutaRecolecta?> DeleteRutaRecolecta(int id)
        {
            RutaRecolecta? rutaRecolecta = await db.RutaRecolecta.FindAsync(id);
            if (rutaRecolecta == null) return rutaRecolecta;
            rutaRecolecta.IsNotDeleted = false;
            db.Entry(rutaRecolecta).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return rutaRecolecta;
        }
    }
}

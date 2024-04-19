using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;
namespace SIGPA.Repositories
{
    public interface IRecolectaControlCalidadRepository
    {
        Task<IEnumerable<RecolectaControlCalidad>> GetRecolectasControlCalidad();
        Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int id);
        Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(RecolectaControlCalidad recolectaControlCalidad);
        Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(RecolectaControlCalidad recolectaControlCalidad);
        Task<RecolectaControlCalidad?> DeleteRecolectaControlCalidad(int id);
    }

    public class RecolectaControlCalidadRepository(ApplicationDbContext db): IRecolectaControlCalidadRepository
    {

        public async Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int id)
        {
            return await db.RecolectaControlCalidad.FindAsync(id);
        }

        public async Task<IEnumerable<RecolectaControlCalidad>> GetRecolectasControlCalidad()
        {
            return await db.RecolectaControlCalidad.ToListAsync();
        }

        public async Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(RecolectaControlCalidad recolectaControlCalidad)
        {
            db.RecolectaControlCalidad.Add(recolectaControlCalidad);
            await db.SaveChangesAsync();
            return recolectaControlCalidad;
        }

        public async Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(RecolectaControlCalidad recolectaControlCalidad)
        {
            db.Entry(recolectaControlCalidad).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return recolectaControlCalidad;
        }

        public async Task<RecolectaControlCalidad?> DeleteRecolectaControlCalidad(int id)
        {
            RecolectaControlCalidad? recolectaControlCalidad = await db.RecolectaControlCalidad.FindAsync(id);
            if (recolectaControlCalidad == null) return recolectaControlCalidad;
            recolectaControlCalidad.IsDeleted = false;
            db.Entry(recolectaControlCalidad).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return recolectaControlCalidad;
        }

    }
}

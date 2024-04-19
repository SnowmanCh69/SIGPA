using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IEstadoResiduosRepository
    {
        Task<IEnumerable<EstadoResiduos>> GetEstadosResiduos();
        Task<EstadoResiduos> GetEstadoResiduo(int id);
        Task<EstadoResiduos> CreateEstadoResiduo(EstadoResiduos estadoResiduos);
        Task<EstadoResiduos> UpdateEstadoResiduo(EstadoResiduos estadoResiduos);
        Task<EstadoResiduos> DeleteEstadoResiduo(int id);

    }
    public class EstadoResiduosRepository(ApplicationDbContext db) : IEstadoResiduosRepository
    {
        public async Task<EstadoResiduos?> GetEstadoResiduo(int id)
        {
            return await db.EstadoResiduos.FindAsync(id);
        }

        public async Task<IEnumerable<EstadoResiduos>> GetEstadosResiduos()
        {
            return await db.EstadoResiduos.ToListAsync();
        }

        public async Task<EstadoResiduos> CreateEstadoResiduo(EstadoResiduos estadoResiduos)
        {
            db.EstadoResiduos.Add(estadoResiduos);
            await db.SaveChangesAsync();
            return estadoResiduos;
        }

        public async Task<EstadoResiduos> UpdateEstadoResiduo(EstadoResiduos estadoResiduos)
        {
            db.Entry(estadoResiduos).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return estadoResiduos;
        }

        public async Task<EstadoResiduos> DeleteEstadoResiduo(int id)
        {
            var estadoResiduos = await db.EstadoResiduos.FindAsync(id);
            if (estadoResiduos == null) return estadoResiduos;
            estadoResiduos.IsDeleted = false;
            await db.SaveChangesAsync();
            return estadoResiduos;
        }
    }
}

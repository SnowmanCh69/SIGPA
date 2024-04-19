using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IEstadoRutaRepository
    {
        Task<IEnumerable<EstadoRuta>> GetEstadosRuta();
        Task<EstadoRuta> GetEstadoRuta(int id);
        Task<EstadoRuta> CreateEstadoRuta(EstadoRuta estadoRuta);
        Task<EstadoRuta> UpdateEstadoRuta(EstadoRuta estadoRuta);
        Task<EstadoRuta> DeleteEstadoRuta(int id);
    }
    public class EstadoRutaRepository(ApplicationDbContext db) : IEstadoRutaRepository
    {

        public async Task<EstadoRuta?> GetEstadoRuta(int id)
        {
            return await db.EstadoRuta.FindAsync(id);
        }

        public async Task<IEnumerable<EstadoRuta>> GetEstadosRuta()
        {
            return await db.EstadoRuta.ToListAsync();
        }

        public async Task<EstadoRuta> CreateEstadoRuta(EstadoRuta estadoRuta)
        {
            db.EstadoRuta.Add(estadoRuta);
            await db.SaveChangesAsync();
            return estadoRuta;
        }

        public async Task<EstadoRuta> UpdateEstadoRuta(EstadoRuta estadoRuta)
        {
            db.Entry(estadoRuta).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return estadoRuta;
        }

        public async Task<EstadoRuta> DeleteEstadoRuta(int id)
        {
            var estadoRuta = await db.EstadoRuta.FindAsync(id);
            if (estadoRuta == null) return estadoRuta;
            estadoRuta.IsDeleted = false;
            await db.SaveChangesAsync();
            return estadoRuta;
        }

    }
}

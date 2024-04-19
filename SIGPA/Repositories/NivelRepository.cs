using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface INivelRepository
    {
        Task<IEnumerable<Nivel>> GetNiveles();
        Task<Nivel?> GetNivel(int id);
        Task<Nivel> CreateNivel(Nivel nivel);
        Task<Nivel> UpdateNivel(Nivel nivel);
        Task<Nivel?> DeleteNivel(int id);

    }
    public class NivelRepository(ApplicationDbContext db) :INivelRepository
    {
        public async Task<Nivel?> GetNivel(int id)
        {
            return await db.Nivel.FindAsync(id);
        }

        public async Task<IEnumerable<Nivel>> GetNiveles()
        {
            return await db.Nivel.ToListAsync();
        }

        public async Task<Nivel> CreateNivel(Nivel nivel)
        {
            db.Nivel.Add(nivel);
            await db.SaveChangesAsync();
            return nivel;
        }

        public async Task<Nivel> UpdateNivel(Nivel nivel)
        {
            db.Entry(nivel).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return nivel;
        }

        public async Task<Nivel?> DeleteNivel(int id)
        {
            Nivel? nivel = await db.Nivel.FindAsync(id);
            if (nivel == null) return nivel;
            nivel.IsDeleted = false;
            db.Entry(nivel).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return nivel;
        }
    }
}

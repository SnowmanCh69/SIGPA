using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface ITipoLogroRepository
    {
        Task<IEnumerable<TipoLogro>> GetTiposLogros();
        Task<TipoLogro?> GetTipoLogro(int id);
        Task<TipoLogro> CreateTipoLogro(TipoLogro tipoLogro);
        Task<TipoLogro> UpdateTipoLogro(TipoLogro tipoLogro);
        Task<TipoLogro?> DeleteTipoLogro(int id);
    }
    public class TipoLogroRepository(ApplicationDbContext db): ITipoLogroRepository
    {
        public async Task<TipoLogro?> GetTipoLogro(int id)
        {
            return await db.TipoLogro.FindAsync(id);
        }

        public async Task<IEnumerable<TipoLogro>> GetTiposLogros()
        {
            return await db.TipoLogro.ToListAsync();
        }

        public async Task<TipoLogro> CreateTipoLogro(TipoLogro tipoLogro)
        {
            db.TipoLogro.Add(tipoLogro);
            await db.SaveChangesAsync();
            return tipoLogro;
        }

        public async Task<TipoLogro> UpdateTipoLogro(TipoLogro tipoLogro)
        {
            db.Entry(tipoLogro).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return tipoLogro;
        }

        public async Task<TipoLogro?> DeleteTipoLogro(int id)
        {
            TipoLogro? tipoLogro = await db.TipoLogro.FindAsync(id);
            if (tipoLogro == null) return tipoLogro;
            tipoLogro.IsDeleted = false;
            db.Entry(tipoLogro).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return tipoLogro;
        }
        
    }
}

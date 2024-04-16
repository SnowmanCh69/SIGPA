using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface ITipoResiduosRepository
    {
        Task<List<TipoResiduos>> GetAll();
        Task<TipoResiduos?> GetTipoResiduos(int id);
        Task<TipoResiduos> CreateTipoResiduos(string nombreTipoResiduos);
        Task<TipoResiduos> UpdateTipoResiduos(TipoResiduos tipoResiduos);
        Task<TipoResiduos> DeleteTipoResiduos(int id);
    }
    public class TipoResiduosRepository : ITipoResiduosRepository
    { 
        private readonly ApplicationDbContext _db;
        public TipoResiduosRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<TipoResiduos>> GetAll()
        {
            return await _db.TipoResiduos.ToListAsync();
        }
        public async Task<TipoResiduos?> GetTipoResiduos(int id)
        {
            return await _db.TipoResiduos.FirstOrDefaultAsync(e => e.IdTipoResiduos == id);
        }
        public async Task<TipoResiduos> CreateTipoResiduos(string nombreTipoResiduos)
        {
            TipoResiduos newTipoResiduos = new TipoResiduos
            {
                NombreTipoResiduos = nombreTipoResiduos
            };
            await _db.TipoResiduos.AddAsync(newTipoResiduos);
            await _db.SaveChangesAsync();
            return newTipoResiduos;
        }
        public async Task<TipoResiduos> UpdateTipoResiduos(TipoResiduos tipoResiduos)
        {
            _db.TipoResiduos.Update(tipoResiduos);
            await _db.SaveChangesAsync();
            return tipoResiduos;
        }
        public async Task<TipoResiduos> DeleteTipoResiduos(int id)
        {
            TipoResiduos tipoResiduos = await GetTipoResiduos(id);

            return tipoResiduos;
        }
    }
}

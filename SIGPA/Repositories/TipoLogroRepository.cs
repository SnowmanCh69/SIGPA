using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface ITipoLogroRepository
    {
        Task<List<TipoLogro>> GetAll();
        Task<TipoLogro?> GetTipoLogro(int id);
        Task<TipoLogro> CreateTipoLogro(string nombreTipoLogro);
        Task<TipoLogro> UpdateTipoLogro(TipoLogro tipoLogro);
        Task<TipoLogro> DeleteTipoLogro(int id);
    }
    public class TipoLogroRepository : ITipoLogroRepository
    {
        private readonly ApplicationDbContext _db;
        public TipoLogroRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<TipoLogro>> GetAll()
        {
            return await _db.TipoLogro.ToListAsync();
        }
        public async Task<TipoLogro?> GetTipoLogro(int id)
        {
            return await _db.TipoLogro.FirstOrDefaultAsync(e => e.IdTipoLogro == id);
        }
        public async Task<TipoLogro> CreateTipoLogro(string nombreTipoLogro)
        {
            TipoLogro newTipoLogro = new TipoLogro
            {
                NombreTipoLogro = nombreTipoLogro
            };
            await _db.TipoLogro.AddAsync(newTipoLogro);
            await _db.SaveChangesAsync();
            return newTipoLogro;
        }
        public async Task<TipoLogro> UpdateTipoLogro(TipoLogro tipoLogro)
        {
            _db.TipoLogro.Update(tipoLogro);
            await _db.SaveChangesAsync();
            return tipoLogro;
        }
        public async Task<TipoLogro> DeleteTipoLogro(int id)
        {
            TipoLogro tipoLogro = await GetTipoLogro(id);

            return tipoLogro;
        }
    }
}

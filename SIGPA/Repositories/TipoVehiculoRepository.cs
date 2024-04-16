using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface ITipoVehiculoRepository
    {
        Task<List<TipoVehiculo>> GetAll();
        Task<TipoVehiculo?> GetTipoVehiculo(int id);
        Task<TipoVehiculo> CreateTipoVehiculo(string nombreTipoVehiculo);
        Task<TipoVehiculo> UpdateTipoVehiculo(TipoVehiculo tipoVehiculo);
        Task<TipoVehiculo> DeleteTipoVehiculo(int id);
    }
    public class TipoVehiculoRepository : ITipoVehiculoRepository
    {
        private readonly ApplicationDbContext _db;
        public TipoVehiculoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<TipoVehiculo>> GetAll()
        {
            return await _db.TipoVehiculo.ToListAsync();
        }
        public async Task<TipoVehiculo?> GetTipoVehiculo(int id)
        {
            return await _db.TipoVehiculo.FirstOrDefaultAsync(e => e.IdTipoVehiculo == id);
        }
        public async Task<TipoVehiculo> CreateTipoVehiculo(string nombreTipoVehiculo)
        {
            TipoVehiculo newTipoVehiculo = new TipoVehiculo
            {
                NombreTipoVehiculo = nombreTipoVehiculo
            };
            await _db.TipoVehiculo.AddAsync(newTipoVehiculo);
            await _db.SaveChangesAsync();
            return newTipoVehiculo;
        }
        public async Task<TipoVehiculo> UpdateTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            _db.TipoVehiculo.Update(tipoVehiculo);
            await _db.SaveChangesAsync();
            return tipoVehiculo;
        }
        public async Task<TipoVehiculo> DeleteTipoVehiculo(int id)
        {
            TipoVehiculo tipoVehiculo = await GetTipoVehiculo(id);

            return tipoVehiculo;
        }
    }
}

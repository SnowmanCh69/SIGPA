using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;


namespace SIGPA.Repositories
{
    public interface ITipoVehiculoRepository
    {
        Task<IEnumerable<TipoVehiculo>> GetTiposVehiculos();
        Task<TipoVehiculo> GetTipoVehiculo(int id);
        Task<TipoVehiculo> CreateTipoVehiculo(TipoVehiculo tipoVehiculo);
        Task<TipoVehiculo> UpdateTipoVehiculo(TipoVehiculo tipoVehiculo);
        Task<TipoVehiculo> DeleteTipoVehiculo(int id);
    }
    public class TipoVehiculoRepository (ApplicationDbContext db) : ITipoVehiculoRepository
    {

        public async Task<TipoVehiculo?> GetTipoVehiculo(int id)
        {
            return await db.TipoVehiculo.FindAsync(id);
        }

        public async Task<IEnumerable<TipoVehiculo>> GetTiposVehiculos()
        {
            return await db.TipoVehiculo.ToListAsync();
        }

        public async Task<TipoVehiculo> CreateTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            db.TipoVehiculo.Add(tipoVehiculo);
            await db.SaveChangesAsync();
            return tipoVehiculo;
        }

        public async Task<TipoVehiculo> UpdateTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            db.Entry(tipoVehiculo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return tipoVehiculo;
        }

        public async Task<TipoVehiculo> DeleteTipoVehiculo(int id)
        {
            var tipoVehiculo = await db.TipoVehiculo.FindAsync(id);
            if (tipoVehiculo == null) return tipoVehiculo;
            tipoVehiculo.IsDeleted = false;
            await db.SaveChangesAsync();
            return tipoVehiculo;
        }

    }

}

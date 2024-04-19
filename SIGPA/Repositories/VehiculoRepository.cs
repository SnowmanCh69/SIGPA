using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;


namespace SIGPA.Repositories
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetVehiculos();
        Task<Vehiculo?> GetVehiculo(int id);
        Task<Vehiculo> CreateVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> UpdateVehiculo(Vehiculo vehiculo);
        Task<Vehiculo?> DeleteVehiculo(int id);

    }
    public class VehiculoRepository(ApplicationDbContext db): IVehiculoRepository
    {
        public async Task<Vehiculo?> GetVehiculo(int id)
        {
            return await db.Vehiculo.FindAsync(id);
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            return await db.Vehiculo.ToListAsync();
        }

        public async Task<Vehiculo> CreateVehiculo(Vehiculo vehiculo)
        {
            db.Vehiculo.Add(vehiculo);
            await db.SaveChangesAsync();
            return vehiculo;
        }

        public async Task<Vehiculo> UpdateVehiculo(Vehiculo vehiculo)
        {
            db.Entry(vehiculo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return vehiculo;
        }

        public async Task<Vehiculo?> DeleteVehiculo(int id)
        {
            Vehiculo? vehiculo = await db.Vehiculo.FindAsync(id);
            if (vehiculo == null) return vehiculo;
            vehiculo.IsDeleted = false;
            db.Entry(vehiculo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return vehiculo;
        }
    }
}

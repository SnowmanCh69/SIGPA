using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IVehiculoRepository
    {
        Task<List<Vehiculo>> GetAll();
        Task<Vehiculo?> GetVehiculo(int id);
        Task<Vehiculo> CreateVehiculo(string marcaVehiculo, string modeloVehiculo, string placaVehiculo, int idTipoVehiculo);
        Task<Vehiculo> UpdateVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> DeleteVehiculo(int id);
    }
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ApplicationDbContext _db;
        public VehiculoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Vehiculo>> GetAll()
        {
            return await _db.Vehiculo.ToListAsync();
        }
        public async Task<Vehiculo?> GetVehiculo(int id)
        {
            return await _db.Vehiculo.FirstOrDefaultAsync(e => e.IdVehiculo == id);
        }
        public async Task<Vehiculo> CreateVehiculo(string marcaVehiculo, string modeloVehiculo, string placaVehiculo, int idTipoVehiculo)
        {
            // Obtener el tipo de vehículo correspondiente a partir de su ID
            var tipoVehiculo = await _db.TipoVehiculo.FindAsync(idTipoVehiculo);

            if (tipoVehiculo == null)
            {
                // Manejar la situación en la que el tipo de vehículo no existe
                throw new Exception("Tipo de Vehículo no encontrado");
            }

            // Crear una nueva instancia de Vehiculo con los valores proporcionados
            Vehiculo newVehiculo = new Vehiculo
            {
                MarcaVehiculo = marcaVehiculo,
                ModeloVehiculo = modeloVehiculo,
                PlacaVehiculo = placaVehiculo,
                IdTipoVehiculo = idTipoVehiculo,
                TipoVehiculo = tipoVehiculo
            };
            await _db.Vehiculo.AddAsync(newVehiculo);
            await _db.SaveChangesAsync();
            return newVehiculo;
        }
        public async Task<Vehiculo> UpdateVehiculo(Vehiculo vehiculo)
        {
            _db.Vehiculo.Update(vehiculo);
            await _db.SaveChangesAsync();
            return vehiculo;
        }
        public async Task<Vehiculo> DeleteVehiculo(int id)
        {
            Vehiculo vehiculo = await GetVehiculo(id);

            return vehiculo;
        }
    }
}

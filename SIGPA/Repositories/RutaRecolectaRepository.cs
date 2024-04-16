using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IRutaRecolectaRepository
    {
        Task<List<RutaRecolecta>> GetAll();
        Task<RutaRecolecta?> GetRutaRecolecta(int id);
        Task<RutaRecolecta> CreateRutaRecolecta(string puntoInicio, string puntoFinalizacion, int idEstadoRuta, int idUsuario, int idVehiculo);
        Task<RutaRecolecta> UpdateRutaRecolecta(RutaRecolecta rutaRecolecta);
        Task<RutaRecolecta> DeleteRutaRecolecta(int id);
    }
    public class RutaRecolectaRepository : IRutaRecolectaRepository
    {
        private readonly ApplicationDbContext _db;
        public RutaRecolectaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<RutaRecolecta>> GetAll()
        {
            return await _db.RutaRecolecta.ToListAsync();
        }
        public async Task<RutaRecolecta?> GetRutaRecolecta(int id)
        {
            return await _db.RutaRecolecta.FirstOrDefaultAsync(e => e.IdRutaRecolecta == id);
        }
        public async Task<RutaRecolecta> CreateRutaRecolecta(string puntoInicio, string puntoFinalizacion, int idEstadoRuta, int idUsuario, int idVehiculo)
        {
            // Obtener el usuario, el estado de ruta y el vehículo correspondientes a partir de sus IDs
            var usuario = await _db.Usuarios.FindAsync(idUsuario);
            var estadoRuta = await _db.EstadoRuta.FindAsync(idEstadoRuta);
            var vehiculo = await _db.Vehiculo.FindAsync(idVehiculo);

            if (usuario == null || estadoRuta == null || vehiculo == null)
            {
                // Manejar la situación en la que el usuario, el estado de ruta o el vehículo no existen
                throw new Exception("Usuario, Estado de Ruta o Vehículo no encontrado");
            }

            // Crear una nueva instancia de RutaRecolecta con los valores proporcionados
            RutaRecolecta newRutaRecolecta = new RutaRecolecta
            {
                PuntoInicio = puntoInicio,
                PuntoFinalizacion = puntoFinalizacion,
                IdEstadoRuta = idEstadoRuta,
                IdUsuario = idUsuario,
                IdVehiculo = idVehiculo,
                Usuario = usuario,
                EstadoRuta = estadoRuta,
                Vehiculo = vehiculo
            };
            await _db.RutaRecolecta.AddAsync(newRutaRecolecta);
            await _db.SaveChangesAsync();
            return newRutaRecolecta;
        }
        public async Task<RutaRecolecta> UpdateRutaRecolecta(RutaRecolecta rutaRecolecta)
        {
            _db.RutaRecolecta.Update(rutaRecolecta);
            await _db.SaveChangesAsync();
            return rutaRecolecta;
        }
        public async Task<RutaRecolecta> DeleteRutaRecolecta(int id)
        {
            RutaRecolecta rutaRecolecta = await GetRutaRecolecta(id);

            return rutaRecolecta;
        }
    }
}

using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace SIGPA.Repositories
{
    public interface IEstadoRutaRepository
    {
        Task<List<EstadoRuta>> GetAll();
        Task<EstadoRuta?> GetEstadoRuta(int id);
        Task<EstadoRuta> CreateEstadoRuta(string nombreEstadoRuta);
        Task<EstadoRuta> UpdateEstadoRuta(EstadoRuta estadoRuta);
        Task<EstadoRuta> DeleteEstadoRuta(int id);
    }
    public class EstadoRutaRepository : IEstadoRutaRepository
    {
        private readonly ApplicationDbContext _db;
        public EstadoRutaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<EstadoRuta>> GetAll()
        {
            return await _db.EstadoRuta.ToListAsync();
        }
        public async Task<EstadoRuta?> GetEstadoRuta(int id)
        {
            return await _db.EstadoRuta.FirstOrDefaultAsync(e => e.IdEstadoRuta == id);
        }
        public async Task<EstadoRuta> CreateEstadoRuta(string nombreEstadoRuta)
        {
            EstadoRuta newEstadoRuta = new EstadoRuta
            {
                NombreEstadoRuta = nombreEstadoRuta
            };
            await _db.EstadoRuta.AddAsync(newEstadoRuta);
            await _db.SaveChangesAsync();

            return newEstadoRuta;
        }
        public async Task<EstadoRuta> UpdateEstadoRuta(EstadoRuta estadoRuta)
        {
            _db.EstadoRuta.Update(estadoRuta);
            await _db.SaveChangesAsync();
            return estadoRuta;
        }
        public async Task<EstadoRuta> DeleteEstadoRuta(int id)
        {
            EstadoRuta estadoRuta = await GetEstadoRuta(id);

            return estadoRuta;
        }
    }
}

using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace SIGPA.Repositories
{
    public interface IEstadoResiduosRepository
    {
        Task<List<EstadoResiduos>> GetAll();
        Task<EstadoResiduos?> GetEstadoResiduos(int id);
        Task<EstadoResiduos> CreateEstadoResiduos(string nombreEstadoResiduos);
        Task<EstadoResiduos> UpdateEstadoResiduos(EstadoResiduos estadoResiduos);
        Task<EstadoResiduos> DeleteEstadoResiduos(int id);
    }


    public class EstadoResiduosRepository
    {
        private readonly ApplicationDbContext _db;
        public EstadoResiduosRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<EstadoResiduos>> GetAll()
        {
            return await _db.EstadoResiduos.ToListAsync();
        }
        public async Task<EstadoResiduos?> GetEstadoResiduos(int id)
        {
            return await _db.EstadoResiduos.FirstOrDefaultAsync(e => e.IdEstadoResiduos == id);
        }
        public async Task<EstadoResiduos> CreateEstadoResiduos(string nombreEstadoResiduos)
        {
            EstadoResiduos newEstadoResiduos = new EstadoResiduos
            {
                NombreEstadoResiduos = nombreEstadoResiduos
            };
            await _db.EstadoResiduos.AddAsync(newEstadoResiduos);
            await _db.SaveChangesAsync();
            return newEstadoResiduos;
        }
        public async Task<EstadoResiduos> UpdateEstadoResiduos(EstadoResiduos estadoResiduos)
        {
            _db.EstadoResiduos.Update(estadoResiduos);
            await _db.SaveChangesAsync();
            return estadoResiduos;
        }
        public async Task<EstadoResiduos> DeleteEstadoResiduos(int id)
        {
            EstadoResiduos estadoResiduos = await GetEstadoResiduos(id);

            return estadoResiduos;
        }
    }
}

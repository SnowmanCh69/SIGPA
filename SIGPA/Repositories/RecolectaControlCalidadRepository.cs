using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IRecolectaControlCalidadRepository
    {
        Task<List<RecolectaControlCalidad>> GetAll();
        Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int id);
        Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(int idControlCalidad, int idResultado, string observaciones);
        Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(RecolectaControlCalidad recolectaControlCalidad);
        Task<RecolectaControlCalidad> DeleteRecolectaControlCalidad(int id);
    }
    public class RecolectaControlCalidadRepository : IRecolectaControlCalidadRepository
    {
        private readonly ApplicationDbContext _db;
        public RecolectaControlCalidadRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<RecolectaControlCalidad>> GetAll()
        {
            return await _db.RecolectaControlCalidad.ToListAsync();
        }
        public async Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int id)
        {
            return await _db.RecolectaControlCalidad.FirstOrDefaultAsync(e => e.IdRecolectaControlCalidad == id);
        }
        public async Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(int idControlCalidad, int idResultado, string observaciones)
        {
            // Obtener el control de calidad y el resultado correspondientes a partir de sus IDs
            var controlCalidad = await _db.ControlCalidad.FindAsync(idControlCalidad);
            var resultado = await _db.Resultado.FindAsync(idResultado);

            if (controlCalidad == null || resultado == null)
            {
                // Manejar la situación en la que el control de calidad o el resultado no existen
                throw new Exception("Control de Calidad o Resultado no encontrado");
            }

            // Crear una nueva instancia de RecolectaControlCalidad con los valores proporcionados
            RecolectaControlCalidad newRecolectaControlCalidad = new RecolectaControlCalidad
            {
                IdControlCalidad = idControlCalidad,
                IdResultado = idResultado,
                Observaciones = observaciones,
                ControlCalidad = controlCalidad,
                Resultado = resultado
            };
            await _db.RecolectaControlCalidad.AddAsync(newRecolectaControlCalidad);
            await _db.SaveChangesAsync();
            return newRecolectaControlCalidad;
        }
        public async Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(RecolectaControlCalidad recolectaControlCalidad)
        {
            _db.RecolectaControlCalidad.Update(recolectaControlCalidad);
            await _db.SaveChangesAsync();
            return recolectaControlCalidad;
        }
        public async Task<RecolectaControlCalidad> DeleteRecolectaControlCalidad(int id)
        {
            RecolectaControlCalidad recolectaControlCalidad = await GetRecolectaControlCalidad(id);

            return recolectaControlCalidad;
        }
    }
}

using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IRecolectaResiduosRepository
    {
        Task<List<RecolectaResiduos>> GetAll();
        Task<RecolectaResiduos?> GetRecolectaResiduos(int id);
        Task<RecolectaResiduos> CreateRecolectaResiduos(int idRutaRecolecta, int idResiduos, int idUsuario, string cantidadRecolectada, DateTime fechaRecoleccion);
        Task<RecolectaResiduos> UpdateRecolectaResiduos(RecolectaResiduos recolectaResiduos);
        Task<RecolectaResiduos> DeleteRecolectaResiduos(int id);
    }
    public class RecolectaResiduosRepository : IRecolectaResiduosRepository
    {
        private readonly ApplicationDbContext _db;
        public RecolectaResiduosRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<RecolectaResiduos>> GetAll()
        {
            return await _db.RecolectaResiduos.ToListAsync();
        }
        public async Task<RecolectaResiduos?> GetRecolectaResiduos(int id)
        {
            return await _db.RecolectaResiduos.FirstOrDefaultAsync(e => e.IdRecolectaResiduos == id);
        }
        public async Task<RecolectaResiduos> CreateRecolectaResiduos(int idRutaRecolecta, int idResiduos, int idUsuario, string cantidadRecolectada, DateTime fechaRecoleccion)
        {
            // Obtener la ruta de recolección, los residuos y el usuario correspondientes a partir de sus IDs
            var rutaRecolecta = await _db.RutaRecolecta.FindAsync(idRutaRecolecta);
            var residuos = await _db.Residuos.FindAsync(idResiduos);
            var usuario = await _db.Usuarios.FindAsync(idUsuario);

            if (rutaRecolecta == null || residuos == null || usuario == null)
            {
                // Manejar la situación en la que la ruta de recolección, los residuos o el usuario no existen
                throw new Exception("Ruta de Recolecta, Residuos o Usuario no encontrado");
            }

            // Crear una nueva instancia de RecolectaResiduos con los valores proporcionados
            RecolectaResiduos newRecolectaResiduos = new RecolectaResiduos
            {
                IdRutaRecolecta = idRutaRecolecta,
                IdResiduos = idResiduos,
                IdUsuario = idUsuario,
                CantidadRecolectada = cantidadRecolectada,
                FechaRecoleccion = fechaRecoleccion,
                RutaRecolecta = rutaRecolecta,
                Residuos = residuos,
                Usuario = usuario
            };
            await _db.RecolectaResiduos.AddAsync(newRecolectaResiduos);
            await _db.SaveChangesAsync();
            return newRecolectaResiduos;
        }
        public async Task<RecolectaResiduos> UpdateRecolectaResiduos(RecolectaResiduos recolectaResiduos)
        {
            _db.RecolectaResiduos.Update(recolectaResiduos);
            await _db.SaveChangesAsync();
            return recolectaResiduos;
        }
        public async Task<RecolectaResiduos> DeleteRecolectaResiduos(int id)
        {
            RecolectaResiduos recolectaResiduos = await GetRecolectaResiduos(id);

            return recolectaResiduos;
        }
    }
}

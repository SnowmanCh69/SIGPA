using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{   
    public interface ILogroRepository
    {
        Task<List<Logro>> GetAll();
        Task<Logro?> GetLogro(int id);
        Task<Logro> CreateLogro(string nombreLogro, string descripcionLogro, int idTipoLogro);
        Task<Logro> UpdateLogro(Logro logro);
        Task<Logro> DeleteLogro(int id);
    }

    public class LogroRepository : ILogroRepository
    {
        private readonly ApplicationDbContext _db;
        public LogroRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Logro>> GetAll()
        {
            return await _db.Logro.ToListAsync();
        }
        public async Task<Logro?> GetLogro(int id)
        {
            return await _db.Logro.FirstOrDefaultAsync(e => e.IdLogro == id);
        }
        public async Task<Logro> CreateLogro(string nombreLogro, string descripcionLogro, int idTipoLogro)
        {
            // Obtener el TipoLogro correspondiente a partir de su ID
            var tipoLogro = await _db.TipoLogro.FindAsync(idTipoLogro);

            if (tipoLogro == null)
            {
                // Manejar la situación en la que el TipoLogro no existe
                throw new Exception("TipoLogro no encontrado");
            }

            // Crear una nueva instancia de Logro con los valores proporcionados
            Logro newLogro = new Logro
            {
                NombreLogro = nombreLogro,
                DescripcionLogro = descripcionLogro,
                TipoLogro = tipoLogro
            };
            await _db.Logro.AddAsync(newLogro);
            await _db.SaveChangesAsync();
            return newLogro;
        }
        public async Task<Logro> UpdateLogro(Logro logro)
        {
            _db.Logro.Update(logro);
            await _db.SaveChangesAsync();
            return logro;
        }
        public async Task<Logro> DeleteLogro(int id)
        {
            Logro logro = await GetLogro(id);

            return logro;
        }
    }
}

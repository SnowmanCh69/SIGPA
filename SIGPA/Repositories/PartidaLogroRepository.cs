using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IPartidaLogroRepository
    {
        Task<List<PartidaLogro>> GetAll();
        Task<PartidaLogro?> GetPartidaLogro(int id);
        Task<PartidaLogro> CreatePartidaLogro(int idPartida, int idLogro, DateTime fechaLogro);
        Task<PartidaLogro> UpdatePartidaLogro(PartidaLogro partidaLogro);
        Task<PartidaLogro> DeletePartidaLogro(int id);
    }
    public class PartidaLogroRepository : IPartidaLogroRepository
    {
        private readonly ApplicationDbContext _db;
        public PartidaLogroRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<PartidaLogro>> GetAll()
        {
            return await _db.PartidaLogro.ToListAsync();
        }
        public async Task<PartidaLogro?> GetPartidaLogro(int id)
        {
            return await _db.PartidaLogro.FirstOrDefaultAsync(e => e.IdPartidaLogro == id);
        }
        public async Task<PartidaLogro> CreatePartidaLogro(int idPartida, int idLogro, DateTime fechaLogro)
        {
            // Obtener la partida y el logro correspondientes a partir de sus IDs
            var partida = await _db.Partida.FindAsync(idPartida);
            var logro = await _db.Logro.FindAsync(idLogro);

            if (partida == null || logro == null)
            {
                // Manejar la situación en la que la partida o el logro no existen
                throw new Exception("Partida o Logro no encontrado");
            }

            // Crear una nueva instancia de PartidaLogro con los valores proporcionados
            PartidaLogro newPartidaLogro = new PartidaLogro
            {
                IdPartida = idPartida,
                IdLogro = idLogro,
                FechaLogro = fechaLogro,
                Partida = partida,
                Logro = logro
            };
            await _db.PartidaLogro.AddAsync(newPartidaLogro);
            await _db.SaveChangesAsync();
            return newPartidaLogro;
        }
        public async Task<PartidaLogro> UpdatePartidaLogro(PartidaLogro partidaLogro)
        {
            _db.PartidaLogro.Update(partidaLogro);
            await _db.SaveChangesAsync();
            return partidaLogro;
        }
        public async Task<PartidaLogro> DeletePartidaLogro(int id)
        {
            PartidaLogro partidaLogro = await GetPartidaLogro(id);

            return partidaLogro;
        }
    }
}

using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface INivelRepository
    {
        Task<List<Nivel>> GetAll();
        Task<Nivel?> GetNivel(int id);
        Task<Nivel> CreateNivel(string nombreNivel);
        Task<Nivel> UpdateNivel(Nivel nivel);
        Task<Nivel> DeleteNivel(int id);
    }
    public class NivelRepository : INivelRepository
    {
        private readonly ApplicationDbContext _db;
        public NivelRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Nivel>> GetAll()
        {
            return await _db.Nivel.ToListAsync();
        }
        public async Task<Nivel?> GetNivel(int id)
        {
            return await _db.Nivel.FirstOrDefaultAsync(e => e.IdNivel == id);
        }
        public async Task<Nivel> CreateNivel(string nombreNivel)
        {
            Nivel newNivel = new Nivel
            {
                NombreNivel = nombreNivel
            };
            await _db.Nivel.AddAsync(newNivel);
            await _db.SaveChangesAsync();
            return newNivel;
        }
        public async Task<Nivel> UpdateNivel(Nivel nivel)
        {
            _db.Nivel.Update(nivel);
            await _db.SaveChangesAsync();
            return nivel;
        }
        public async Task<Nivel> DeleteNivel(int id)
        {
            Nivel nivel = await GetNivel(id);

            return nivel;
        }
    }
}

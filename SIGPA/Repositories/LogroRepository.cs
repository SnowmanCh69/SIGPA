using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{

    public interface ILogroRepository
    {
        Task<IEnumerable<Logro>> GetLogros();
        Task<Logro?> GetLogro(int id);
        Task<Logro> CreateLogro(Logro logro);
        Task<Logro> UpdateLogro(Logro logro);
        Task<Logro?> DeleteLogro(int id);

    }
    public class LogroRepository ( ApplicationDbContext db) : ILogroRepository
    {
        public async Task<Logro?> GetLogro(int id)
        {
            return await db.Logro.FindAsync(id);
        }

        public async Task<IEnumerable<Logro>> GetLogros()
        {
            return await db.Logro.ToListAsync();
        }

        public async Task<Logro> CreateLogro(Logro logro)
        {
            db.Logro.Add(logro);
            await db.SaveChangesAsync();
            return logro;
        }

        public async Task<Logro> UpdateLogro(Logro logro)
        {
            db.Entry(logro).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return logro;
        }

        public async Task<Logro?> DeleteLogro(int id)
        {
            Logro? logro = await db.Logro.FindAsync(id);
            if (logro == null) return logro;
            logro.IsDeleted = false;
            db.Entry(logro).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return logro;
        }

    }
}

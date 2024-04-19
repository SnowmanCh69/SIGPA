using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IPartidaLogroRepository
    {
        Task<IEnumerable<PartidaLogro>> GetPartidasLogros();
        Task<PartidaLogro> GetPartidaLogro(int id);
        Task<PartidaLogro> CreatePartidaLogro(PartidaLogro partidaLogro);
        Task<PartidaLogro> UpdatePartidaLogro(PartidaLogro partidaLogro);
        Task<PartidaLogro> DeletePartidaLogro(int id);
    }
    public class PartidaLogroRepository(ApplicationDbContext  db): IPartidaLogroRepository
    {
        public async Task<PartidaLogro?> GetPartidaLogro(int id)
        {
            return await db.PartidaLogro.FindAsync(id);
        }

        public async Task<IEnumerable<PartidaLogro>> GetPartidasLogros()
        {
            return await db.PartidaLogro.ToListAsync();
        }

        public async Task<PartidaLogro> CreatePartidaLogro(PartidaLogro partidaLogro)
        {
            db.PartidaLogro.Add(partidaLogro);
            await db.SaveChangesAsync();
            return partidaLogro;
        }

        public async Task<PartidaLogro> UpdatePartidaLogro(PartidaLogro partidaLogro)
        {
            db.Entry(partidaLogro).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return partidaLogro;
        }

        public async Task<PartidaLogro> DeletePartidaLogro(int id)
        {
            var partidaLogro = await db.PartidaLogro.FindAsync(id);
            if (partidaLogro == null) return partidaLogro;
            partidaLogro.IsDeleted = false;
            await db.SaveChangesAsync();
            return partidaLogro;
        }
    }
}

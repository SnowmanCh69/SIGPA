using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IResultadoRepository
    {
        Task<IEnumerable<Resultado>> GetResultados();
        Task<Resultado> GetResultado(int id);
        Task<Resultado> CreateResultado(Resultado resultado);
        Task<Resultado> UpdateResultado(Resultado resultado);
        Task<Resultado> DeleteResultado(int id);

    }
    public class ResultadoRepository(ApplicationDbContext db): IResultadoRepository
    {
        public async Task<Resultado?> GetResultado(int id)
        {
            return await db.Resultado.FindAsync(id);
        }

        public async Task<IEnumerable<Resultado>> GetResultados()
        {
            return await db.Resultado.ToListAsync();
        }

        public async Task<Resultado> CreateResultado(Resultado resultado)
        {
            db.Resultado.Add(resultado);
            await db.SaveChangesAsync();
            return resultado;
        }

        public async Task<Resultado> UpdateResultado(Resultado resultado)
        {
            db.Entry(resultado).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return resultado;
        }

        public async Task<Resultado> DeleteResultado(int id)
        {
            var resultado = await db.Resultado.FindAsync(id);
            if (resultado == null) return resultado;
            resultado.IsDeleted = false;
            await db.SaveChangesAsync();
            return resultado;
        }
    }
}

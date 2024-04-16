using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IResultadoRepository
    {
        Task<List<Resultado>> GetAll();
        Task<Resultado?> GetResultado(int id);
        Task<Resultado> CreateResultado(string nombreResultado);
        Task<Resultado> UpdateResultado(Resultado resultado);
        Task<Resultado> DeleteResultado(int id);
    }
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly ApplicationDbContext _db;
        public ResultadoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Resultado>> GetAll()
        {
            return await _db.Resultado.ToListAsync();
        }
        public async Task<Resultado?> GetResultado(int id)
        {
            return await _db.Resultado.FirstOrDefaultAsync(e => e.IdResultado == id);
        }
        public async Task<Resultado> CreateResultado(string nombreResultado)
        {
            Resultado newResultado = new Resultado
            {
                NombreResultado = nombreResultado
            };
            await _db.Resultado.AddAsync(newResultado);
            await _db.SaveChangesAsync();
            return newResultado;
        }
        public async Task<Resultado> UpdateResultado(Resultado resultado)
        {
            _db.Resultado.Update(resultado);
            await _db.SaveChangesAsync();
            return resultado;
        }
        public async Task<Resultado> DeleteResultado(int id)
        {
            Resultado resultado = await GetResultado(id);

            return resultado;
        }
    }
}

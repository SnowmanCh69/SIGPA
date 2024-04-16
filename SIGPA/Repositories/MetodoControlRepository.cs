using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IMetodoControlRepository
    {
        Task<List<MetodoControl>> GetAll();
        Task<MetodoControl?> GetMetodoControl(int id);
        Task<MetodoControl> CreateMetodoControl(string nombreMetodoControl, string descripcionMetodoControl);
        Task<MetodoControl> UpdateMetodoControl(MetodoControl metodoControl);
        Task<MetodoControl> DeleteMetodoControl(int id);
    }
    public class MetodoControlRepository : IMetodoControlRepository
    {
        private readonly ApplicationDbContext _db;
        public MetodoControlRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<MetodoControl>> GetAll()
        {
            return await _db.MetodoControl.ToListAsync();
        }
        public async Task<MetodoControl?> GetMetodoControl(int id)
        {
            return await _db.MetodoControl.FirstOrDefaultAsync(e => e.IdMetodoControl == id);
        }
        public async Task<MetodoControl> CreateMetodoControl(string nombreMetodoControl, string descripcionMetodoControl)
        {
            MetodoControl newMetodoControl = new MetodoControl
            {
                NombreMetodoControl = nombreMetodoControl,
                DescripcionMetodoControl = descripcionMetodoControl
            };
            await _db.MetodoControl.AddAsync(newMetodoControl);
            await _db.SaveChangesAsync();
            return newMetodoControl;
        }
        public async Task<MetodoControl> UpdateMetodoControl(MetodoControl metodoControl)
        {
            _db.MetodoControl.Update(metodoControl);
            await _db.SaveChangesAsync();
            return metodoControl;
        }
        public async Task<MetodoControl> DeleteMetodoControl(int id)
        {
            MetodoControl metodoControl = await GetMetodoControl(id);

            return metodoControl;
        }

    }
}

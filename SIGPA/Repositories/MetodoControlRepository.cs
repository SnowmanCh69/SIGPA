using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IMetodoControlRepository
    {
        Task<IEnumerable<MetodoControl>> GetMetodosControl();
        Task<MetodoControl?> GetMetodoControl(int id);
        Task<MetodoControl> CreateMetodoControl(MetodoControl metodoControl);
        Task<MetodoControl> UpdateMetodoControl(MetodoControl metodoControl);
        Task<MetodoControl?> DeleteMetodoControl(int id);

    }
    public class MetodoControlRepository (ApplicationDbContext db) : IMetodoControlRepository
    {
        public async Task<MetodoControl?> GetMetodoControl(int id)
        {
            return await db.MetodoControl.FindAsync(id);
        }

        public async Task<IEnumerable<MetodoControl>> GetMetodosControl()
        {
            return await db.MetodoControl.ToListAsync();
        }

        public async Task<MetodoControl> CreateMetodoControl(MetodoControl metodoControl)
        {
            db.MetodoControl.Add(metodoControl);
            await db.SaveChangesAsync();
            return metodoControl;
        }

        public async Task<MetodoControl> UpdateMetodoControl(MetodoControl metodoControl)
        {
            db.Entry(metodoControl).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return metodoControl;
        }

        public async Task<MetodoControl?> DeleteMetodoControl(int id)
        {
            MetodoControl? metodoControl = await db.MetodoControl.FindAsync(id);
            if (metodoControl == null) return metodoControl;
            metodoControl.IsNotDeleted = false;
            db.Entry(metodoControl).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return metodoControl;

        }
    }
}

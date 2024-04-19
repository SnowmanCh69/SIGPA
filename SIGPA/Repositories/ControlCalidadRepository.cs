using Microsoft.EntityFrameworkCore;
using SIGPA.Context;
using SIGPA.Models;

namespace SIGPA.Repositories
{
    public interface IControlCalidadRepository
    {
        Task<IEnumerable<ControlCalidad>> GetControlesCalidad();
        Task<ControlCalidad?> GetControlCalidad(int id);
        Task<ControlCalidad> CreateControlCalidad(ControlCalidad controlCalidad);
        Task<ControlCalidad> UpdateControlCalidad(ControlCalidad controlCalidad);
        Task<ControlCalidad?> DeleteControlCalidad(int id);

    }

    public class ControlCalidadRepository(ApplicationDbContext db) : IControlCalidadRepository
    {
        
        //Obtener control calidad por su ID
        
        public async Task<ControlCalidad?> GetControlCalidad(int id)
        {
            return await db.ControlCalidad.FindAsync(id);
        }

        //Obtener todos los controles de calidad

        public async Task<IEnumerable<ControlCalidad>> GetControlesCalidad()
        {
            return await db.ControlCalidad.ToListAsync();
        }

        //Crear un control de calidad
        public async Task<ControlCalidad> CreateControlCalidad(ControlCalidad controlCalidad)
        {
            db.ControlCalidad.Add(controlCalidad);
            await db.SaveChangesAsync();
            return controlCalidad;
        }

        //Actualizar un control de calidad
        public async Task<ControlCalidad> UpdateControlCalidad(ControlCalidad controlCalidad)
        {
            db.Entry(controlCalidad).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return controlCalidad;
        }

        //Eliminar un control de calidad
        public async Task<ControlCalidad?> DeleteControlCalidad(int id)
        {
            ControlCalidad? controlCalidad = await db.ControlCalidad.FindAsync(id);
            if (controlCalidad == null) return controlCalidad;
            controlCalidad.IsDeleted = false; 
            db.Entry(controlCalidad).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return controlCalidad;
        }
    }
}

using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace SIGPA.Repositories
{

    public interface IControlCalidadRepository
    {
        Task<List<ControlCalidad>> GetAll();
        Task<ControlCalidad?> GetControlCalidad(int id);
        Task<ControlCalidad> CreateControlCalidad(DateTime fechaControl, int idUsuario, int idMetodoControl);
        Task<ControlCalidad> UpdateControlCalidad(ControlCalidad controlCalidad);
        Task<ControlCalidad> DeleteControlCalidad(int id);

    }

    public class ControlCalidadRepository : IControlCalidadRepository
    {
        private readonly ApplicationDbContext _db;
        public ControlCalidadRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<ControlCalidad>> GetAll()
        {
            return await _db.ControlCalidad.ToListAsync();
        }
        public async Task<ControlCalidad?> GetControlCalidad(int id)
        {
            return await _db.ControlCalidad.FirstOrDefaultAsync(c => c.IdControlCalidad == id);
        }
        public async Task<ControlCalidad> CreateControlCalidad(DateTime fechaControl, int idUsuario, int idMetodoControl)
        {
            // Obtener el usuario y método de control correspondientes
            var usuario = await _db.Usuarios.FindAsync(idUsuario);
            var metodoControl = await _db.MetodoControl.FindAsync(idMetodoControl);

            if (usuario == null || metodoControl == null)
            {
                // Manejar la situación en la que el usuario o el método de control no existen
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Usuario o Método de Control no encontrado");
            }

            // Crear una nueva instancia de ControlCalidad con los valores proporcionados
            ControlCalidad newControlCalidad = new ControlCalidad
            {
                FechaControl = fechaControl,
                IdUsuario = idUsuario,
                IdMetodoControl = idMetodoControl,
                Usuario = usuario,
                MetodoControl = metodoControl
            };

            await _db.ControlCalidad.AddAsync(newControlCalidad);
            await _db.SaveChangesAsync();

            return newControlCalidad;
        }
        public async Task<ControlCalidad> UpdateControlCalidad(ControlCalidad controlCalidad)
        {
            _db.ControlCalidad.Update(controlCalidad);
            await _db.SaveChangesAsync();
            return controlCalidad;
        }
        public async Task<ControlCalidad> DeleteControlCalidad(int id)
        {
            ControlCalidad controlCalidad = await GetControlCalidad(id);

            return await UpdateControlCalidad(controlCalidad);

        }
    }
}

using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IControlCalidadService
    {
        Task<IEnumerable<ControlCalidad>> GetControlesCalidad();
        Task<ControlCalidad?> GetControlCalidad(int id);
        Task<ControlCalidad> CreateControlCalidad(
            DateOnly FechaControl,
            int IdUsuario,
            int IdMetodoControl
            );
        Task<ControlCalidad> UpdateControlCalidad(
           int IdControlCalidad,
           DateOnly? FechaControl,
           int? IdUsuario,
           int? IdMetodoControl
            );
        Task<ControlCalidad?> DeleteControlCalidad(int id);
    }
    public class ControlCalidadService(IControlCalidadRepository controlCalidadRepository) : IControlCalidadService
    {
       
        public async Task<ControlCalidad?> GetControlCalidad(int id)
        {
            return await controlCalidadRepository.GetControlCalidad(id);
        }

        public async Task<IEnumerable<ControlCalidad>> GetControlesCalidad()
        {
            return await controlCalidadRepository.GetControlesCalidad();
        }

        public async Task<ControlCalidad> CreateControlCalidad(
          DateOnly FechaControl,
          int IdUsuario,
          int IdMetodoControl
         )
        {
            return await controlCalidadRepository.CreateControlCalidad(new ControlCalidad
            { 
                FechaControl = FechaControl,
                IdUsuario = IdUsuario,
                IdMetodoControl = IdMetodoControl
                });
            }

        public async Task<ControlCalidad> UpdateControlCalidad(
            
            int IdControlCalidad,
            DateOnly? FechaControl,
            int? IdUsuario,
            int? IdMetodoControl
            )
        {
            ControlCalidad? controlCalidad = await controlCalidadRepository.GetControlCalidad(IdControlCalidad);
            if (controlCalidad == null) throw new Exception("Control de calidad no encontrado");

            controlCalidad.FechaControl = FechaControl ?? controlCalidad.FechaControl;
            controlCalidad.IdUsuario = IdUsuario ?? controlCalidad.IdUsuario;
            controlCalidad.IdMetodoControl = IdMetodoControl ?? controlCalidad.IdMetodoControl;
            return await controlCalidadRepository.UpdateControlCalidad(controlCalidad);
        }

        public async Task<ControlCalidad?> DeleteControlCalidad(int id)
        {
            return await controlCalidadRepository.DeleteControlCalidad(id);
        }
      
    }
}


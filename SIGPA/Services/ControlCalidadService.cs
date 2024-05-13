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
            int IdResiduo,
            int IdMetodoControl,
            string Observaciones
            );
        Task<ControlCalidad> UpdateControlCalidad(
           int IdControlCalidad,
           DateOnly? FechaControl,
           int? IdUsuario,
           int? IdResiduo,
           int? IdMetodoControl,
           string? Observaciones
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
          int IdResiduo,
          int IdMetodoControl,
          string Observaciones
         )
        {
            return await controlCalidadRepository.CreateControlCalidad(new ControlCalidad
            { 
                FechaControl = FechaControl,
                IdUsuario = IdUsuario,
                IdResiduo = IdResiduo,
                IdMetodoControl = IdMetodoControl,
                Observaciones = Observaciones
                });
            }

        public async Task<ControlCalidad> UpdateControlCalidad(
            
            int IdControlCalidad,
            DateOnly? FechaControl,
            int? IdUsuario,
            int? IdResiduo,
            int? IdMetodoControl,
            string? Observaciones
            )
        {
            ControlCalidad? controlCalidad = await controlCalidadRepository.GetControlCalidad(IdControlCalidad);
            if (controlCalidad == null) throw new Exception("Control de calidad no encontrado");
            controlCalidad.FechaControl = FechaControl ?? controlCalidad.FechaControl;
            controlCalidad.IdUsuario = IdUsuario ?? controlCalidad.IdUsuario;
            controlCalidad.IdResiduo = IdResiduo ?? controlCalidad.IdResiduo;
            controlCalidad.IdMetodoControl = IdMetodoControl ?? controlCalidad.IdMetodoControl;
            controlCalidad.Observaciones = Observaciones ?? controlCalidad.Observaciones;
            return await controlCalidadRepository.UpdateControlCalidad(controlCalidad);
        }

        public async Task<ControlCalidad?> DeleteControlCalidad(int id)
        {
            return await controlCalidadRepository.DeleteControlCalidad(id);
        }
      
    }
}


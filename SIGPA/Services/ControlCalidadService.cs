using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IControlCalidadService
    {
        Task<List<ControlCalidad>> GetAll();
        Task<ControlCalidad?> GetControlCalidad(int IdControlCalidad);
        Task<ControlCalidad> CreateControlCalidad(DateTime fechaControl, int idUsuario, int idMetodoControl);
        Task<ControlCalidad> UpdateControlCalidad(
            int IdControlCalidad,
            DateTime? fechaControl = null,
            int? idUsuario = null,
            int? idMetodoControl =null
        );
        Task<ControlCalidad> DeleteControlCalidad(int idControlCalidad);

    }
    public class ControlCalidadService
    {

        private readonly IControlCalidadRepository _controlCalidadRepository;
        public ControlCalidadService(IControlCalidadRepository controlCalidadRepository)
        {
            _controlCalidadRepository = controlCalidadRepository;
        }
        
        public async Task<List<ControlCalidad>> GetAll()
        {
            return await _controlCalidadRepository.GetAll();
        }

        public async Task<ControlCalidad?> GetControlCalidad(int IdControlCalidad)
        {
            return await _controlCalidadRepository.GetControlCalidad(IdControlCalidad);
        }

        public async Task<ControlCalidad> CreateControlCalidad(DateTime fechaControl, int idUsuario, int idMetodoControl)
        {
            return await _controlCalidadRepository.CreateControlCalidad(fechaControl, idUsuario, idMetodoControl);
        }

        public async Task<ControlCalidad> UpdateControlCalidad(
            int IdControlCalidad,
            DateTime? fechaControl = null,
            int? idUsuario = null,
            int? idMetodoControl =null
          )
        {
            var controlCalidad = await _controlCalidadRepository.GetControlCalidad(IdControlCalidad);
            if (controlCalidad == null)
            {
                // Manejar la situación en la que el control de calidad no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Control de Calidad no encontrado");
            }

            if (fechaControl != null)
            {
                controlCalidad.FechaControl = fechaControl.Value;
            }

            if (idUsuario != null)
            {
                controlCalidad.IdUsuario = idUsuario.Value;
            }

            if (idMetodoControl != null)
            {
                controlCalidad.IdMetodoControl = idMetodoControl.Value;
            }

            return await _controlCalidadRepository.UpdateControlCalidad(controlCalidad);
        }

        public async Task<ControlCalidad> DeleteControlCalidad(int idControlCalidad)
        {
            return await _controlCalidadRepository.DeleteControlCalidad(idControlCalidad);
        }

    }
}

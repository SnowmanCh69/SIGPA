using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IMetodoControlService
    {
        Task<List<MetodoControl>> GetAll();
        Task<MetodoControl?> GetMetodoControl(int IdMetodoControl);
        Task<MetodoControl> CreateMetodoControl(string nombreMetodoControl, string descripcionMetodoControl);
        Task<MetodoControl> UpdateMetodoControl(
         int IdMetodoControl,
         string? nombreMetodoControl = null,
         string? descripcionMetodoControl = null
                                                        
     );
        Task<MetodoControl> DeleteMetodoControl(int idMetodoControl);
    }
    public class MetodoControlService : IMetodoControlService
    {
        private readonly IMetodoControlRepository _metodoControlRepository;
        public MetodoControlService(IMetodoControlRepository metodoControlRepository)
        {
            _metodoControlRepository = metodoControlRepository;
        }

        public async Task<List<MetodoControl>> GetAll()
        {
            return await _metodoControlRepository.GetAll();
        }

        public async Task<MetodoControl?> GetMetodoControl(int IdMetodoControl)
        {
            return await _metodoControlRepository.GetMetodoControl(IdMetodoControl);
        }

        public async Task<MetodoControl> CreateMetodoControl(string nombreMetodoControl, string descripcionMetodoControl)
        {
            return await _metodoControlRepository.CreateMetodoControl(nombreMetodoControl, descripcionMetodoControl);
        }

        public async Task<MetodoControl> UpdateMetodoControl(
            int IdMetodoControl,
            string? nombreMetodoControl = null,
            string? descripcionMetodoControl = null
         )
        {
            var metodoControl = await _metodoControlRepository.GetMetodoControl(IdMetodoControl);
            if (metodoControl == null)
            {
                // Manejar la situación en la que el metodoControl no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("MetodoControl no encontrado");
            }

            if (nombreMetodoControl != null)
            {
                metodoControl.NombreMetodoControl = nombreMetodoControl;
            }

            if (descripcionMetodoControl != null)
            {
                metodoControl.DescripcionMetodoControl = descripcionMetodoControl;
            }

            return await _metodoControlRepository.UpdateMetodoControl(metodoControl);
        }

        public async Task<MetodoControl> DeleteMetodoControl(int idMetodoControl)
        {
            return await _metodoControlRepository.DeleteMetodoControl(idMetodoControl);
        }
    }

}

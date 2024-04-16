using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    public interface IEstadoResiduosService
    {
        Task<List<EstadoResiduos>> GetAll();
        Task<EstadoResiduos?> GetEstadoResiduos(int IdEstadoResiduos);
        Task<EstadoResiduos> CreateEstadoResiduos(string nombreEstadoResiduos);
        Task<EstadoResiduos> UpdateEstadoResiduos(
           int IdEstadoResiduos,
           string? nombreEstadoResiduos = null
        );
        Task<EstadoResiduos> DeleteEstadoResiduos(int idEstadoResiduos);

    }
    public class EstadoResiduosService : IEstadoResiduosService
    {

        private readonly IEstadoResiduosRepository _estadoResiduosRepository;
        public EstadoResiduosService(IEstadoResiduosRepository estadoResiduosRepository)
        {
            _estadoResiduosRepository = estadoResiduosRepository;
        }

        public async Task<List<EstadoResiduos>> GetAll()
        {
            return await _estadoResiduosRepository.GetAll();
        }

        public async Task<EstadoResiduos?> GetEstadoResiduos(int IdEstadoResiduos)
        {
            return await _estadoResiduosRepository.GetEstadoResiduos(IdEstadoResiduos);
        }

        public async Task<EstadoResiduos> CreateEstadoResiduos(string nombreEstadoResiduos)
        {
            return await _estadoResiduosRepository.CreateEstadoResiduos(nombreEstadoResiduos);
        }

        public async Task<EstadoResiduos> UpdateEstadoResiduos(
          int IdEstadoResiduos,
          string? nombreEstadoResiduos = null
         )
        {
            var estadoResiduos = await _estadoResiduosRepository.GetEstadoResiduos(IdEstadoResiduos);
            if (estadoResiduos == null)
            {
                // Manejar la situación en la que el estado de residuos no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Estado de Residuos no encontrado");
            }

            if (nombreEstadoResiduos != null)
            {
                estadoResiduos.NombreEstadoResiduos = nombreEstadoResiduos;
            }

            return await _estadoResiduosRepository.UpdateEstadoResiduos(estadoResiduos);
        }

        public async Task<EstadoResiduos> DeleteEstadoResiduos(int idEstadoResiduos)
        {
            return await _estadoResiduosRepository.DeleteEstadoResiduos(idEstadoResiduos);
        }
    }
    
}

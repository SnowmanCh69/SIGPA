using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    public interface IEstadoRutaService
    {
        Task<List<EstadoRuta>> GetAll();
        Task<EstadoRuta?> GetEstadoRuta(int IdEstadoRuta);
        Task<EstadoRuta> CreateEstadoRuta(string nombreEstadoRuta);
        Task<EstadoRuta> UpdateEstadoRuta(
          int IdEstadoRuta,
          string? nombreEstadoRuta = null
        );
        Task<EstadoRuta> DeleteEstadoRuta(int idEstadoRuta);

    }
    public class EstadoRutaService: IEstadoRutaService
    {

        private readonly IEstadoRutaRepository _estadoRutaRepository;
        public EstadoRutaService(IEstadoRutaRepository estadoRutaRepository)
        {
            _estadoRutaRepository = estadoRutaRepository;
        }

        public async Task<List<EstadoRuta>> GetAll()
        {
            return await _estadoRutaRepository.GetAll();
        }

        public async Task<EstadoRuta?> GetEstadoRuta(int IdEstadoRuta)
        {
            return await _estadoRutaRepository.GetEstadoRuta(IdEstadoRuta);
        }

        public async Task<EstadoRuta> CreateEstadoRuta(string nombreEstadoRuta)
        {
            return await _estadoRutaRepository.CreateEstadoRuta(nombreEstadoRuta);
        }

        public async Task<EstadoRuta> UpdateEstadoRuta(
                     int IdEstadoRuta,
                              string? nombreEstadoRuta = null
                   )
        {
            var estadoRuta = await _estadoRutaRepository.GetEstadoRuta(IdEstadoRuta);
            if (estadoRuta == null)
            {
                // Manejar la situación en la que el estado de ruta no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Estado de Ruta no encontrado");
            }

            if (nombreEstadoRuta != null)
            {
                estadoRuta.NombreEstadoRuta = nombreEstadoRuta;
            }

            return await _estadoRutaRepository.UpdateEstadoRuta(estadoRuta);
        }

        public async Task<EstadoRuta> DeleteEstadoRuta(int idEstadoRuta)
        {
            return await _estadoRutaRepository.DeleteEstadoRuta(idEstadoRuta);
        }

    }
    
}

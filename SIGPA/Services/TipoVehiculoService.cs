using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface ITipoVehiculoService
    {
        Task<List<TipoVehiculo>> GetAll();
        Task<TipoVehiculo> GetTipoVehiculo(int IdTipoVehiculo);
        Task<TipoVehiculo> CreateTipoVehiculo(string NombreTipoVehiculo);
        Task<TipoVehiculo> UpdateTipoVehiculo(
         int IdTipoVehiculo,
         string? NombreTipoVehiculo = null
     );
        Task<TipoVehiculo> DeleteTipoVehiculo(int IdTipoVehiculo);
    }
    public class TipoVehiculoService : ITipoVehiculoService
    {
        private readonly ITipoVehiculoRepository _tipoVehiculoRepository;
        public TipoVehiculoService(ITipoVehiculoRepository tipoVehiculoRepository)
        {
            _tipoVehiculoRepository = tipoVehiculoRepository;
        }

        public async Task<List<TipoVehiculo>> GetAll()
        {
            return await _tipoVehiculoRepository.GetAll();
        }

        public async Task<TipoVehiculo> GetTipoVehiculo(int IdTipoVehiculo)
        {
            return await _tipoVehiculoRepository.GetTipoVehiculo(IdTipoVehiculo);
        }

        public async Task<TipoVehiculo> CreateTipoVehiculo(string NombreTipoVehiculo)
        {
            return await _tipoVehiculoRepository.CreateTipoVehiculo(NombreTipoVehiculo);
        }

        public async Task<TipoVehiculo> UpdateTipoVehiculo(
                      int IdTipoVehiculo,
                                 string? NombreTipoVehiculo = null
                              )
        {
            var tipoVehiculo = await _tipoVehiculoRepository.GetTipoVehiculo(IdTipoVehiculo);
            if (tipoVehiculo == null)
            {
                throw new Exception("TipoVehiculo not found");
            }

            if (NombreTipoVehiculo != null)
            {
                tipoVehiculo.NombreTipoVehiculo = NombreTipoVehiculo;
            }

            return await _tipoVehiculoRepository.UpdateTipoVehiculo(tipoVehiculo);
        }

        public async Task<TipoVehiculo> DeleteTipoVehiculo(int IdTipoVehiculo)
        {

            return await _tipoVehiculoRepository.DeleteTipoVehiculo(IdTipoVehiculo);
        }
        
    }
    
}

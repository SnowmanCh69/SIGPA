using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface ITipoVehiculoService
    {
        Task<IEnumerable<TipoVehiculo>> GetTipoVehiculo();
        Task<TipoVehiculo?> GetTipoVehiculo(int id);
        Task<TipoVehiculo> CreateTipoVehiculo(
           string NombreTipoVehiculo
         );
        Task<TipoVehiculo> UpdateTipoVehiculo(
            int IdTipoVehiculo,
             string? NombreTipoVehiculo
        );
        Task<TipoVehiculo> DeleteTipoVehiculo(int id);
    }
    public class TipoVehiculoService(ITipoVehiculoRepository tipoVehiculoRepository) : ITipoVehiculoService
    {
        public async Task<TipoVehiculo?> GetTipoVehiculo(int id)
        {
            return await tipoVehiculoRepository.GetTipoVehiculo(id);
        }

        public async Task<IEnumerable<TipoVehiculo>> GetTipoVehiculo()
        {
            return await tipoVehiculoRepository.GetTiposVehiculos();
        }

        public async Task<TipoVehiculo> CreateTipoVehiculo(
                      string NombreTipoVehiculo
                     )
        {
            return await tipoVehiculoRepository.CreateTipoVehiculo(new TipoVehiculo
            {
                NombreTipoVehiculo = NombreTipoVehiculo
            });
        }

        public async Task<TipoVehiculo> UpdateTipoVehiculo(
               int IdTipoVehiculo,
               string? NombreTipoVehiculo
           )
        {
            TipoVehiculo? tipoVehiculo = await tipoVehiculoRepository.GetTipoVehiculo(IdTipoVehiculo);
            if (tipoVehiculo == null) throw new Exception("TipoVehiculo not found");
            tipoVehiculo.NombreTipoVehiculo = NombreTipoVehiculo ?? tipoVehiculo.NombreTipoVehiculo;
            return await tipoVehiculoRepository.UpdateTipoVehiculo(tipoVehiculo);
        }

        public async Task<TipoVehiculo> DeleteTipoVehiculo(int id)
        {
            return await tipoVehiculoRepository.DeleteTipoVehiculo(id);
        }
    }
}

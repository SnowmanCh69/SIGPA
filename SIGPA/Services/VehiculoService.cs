using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IVehiculoService
    {
        Task<IEnumerable<Vehiculo>> GetVehiculos();
        Task<Vehiculo?> GetVehiculo(int id);
        Task<Vehiculo> CreateVehiculo(
          string MarcaVehiculo,
          string ModeloVehiculo,
          string PlacaVehiculo,
          int IdTipoVehiculo                          
         );
        Task<Vehiculo> UpdateVehiculo(
           int IdVehiculo,
           string? MarcaVehiculo,
           string? ModeloVehiculo,
           string? PlacaVehiculo,
           int? IdTipoVehiculo
        );
        Task<Vehiculo?> DeleteVehiculo(int id);

    }

    public class VehiculoService(IVehiculoRepository vehiculoRepository) : IVehiculoService
    {

        public async Task<Vehiculo?> GetVehiculo(int id)
        {
            return await vehiculoRepository.GetVehiculo(id);
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            return await vehiculoRepository.GetVehiculos();
        }

        public async Task<Vehiculo> CreateVehiculo(
            string MarcaVehiculo,
            string ModeloVehiculo,
            string PlacaVehiculo,
            int IdTipoVehiculo
          )
        {
            return await vehiculoRepository.CreateVehiculo(new Vehiculo
            {
                MarcaVehiculo = MarcaVehiculo,
                ModeloVehiculo = ModeloVehiculo,
                PlacaVehiculo = PlacaVehiculo,
                IdTipoVehiculo = IdTipoVehiculo
            });
        }

        public async Task<Vehiculo> UpdateVehiculo(
            int IdVehiculo,
            string? MarcaVehiculo,
            string? ModeloVehiculo,
            string? PlacaVehiculo,
            int? IdTipoVehiculo
         )
        {
            Vehiculo? vehiculo = await vehiculoRepository.GetVehiculo(IdVehiculo);
            if (vehiculo == null) throw new Exception("Vehiculo not found");
            vehiculo.MarcaVehiculo = MarcaVehiculo ?? vehiculo.MarcaVehiculo;
            vehiculo.ModeloVehiculo = ModeloVehiculo ?? vehiculo.ModeloVehiculo;
            vehiculo.PlacaVehiculo = PlacaVehiculo ?? vehiculo.PlacaVehiculo;
            vehiculo.IdTipoVehiculo = IdTipoVehiculo ?? vehiculo.IdTipoVehiculo;
            return await vehiculoRepository.UpdateVehiculo(vehiculo);
        }

        public async Task<Vehiculo?> DeleteVehiculo(int id)
        {
            return await vehiculoRepository.DeleteVehiculo(id);
        }
    }
}

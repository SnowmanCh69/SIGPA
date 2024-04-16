using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IVehiculoService
    {
        Task<List<Vehiculo>> GetAll();
        Task<Vehiculo> GetVehiculo(int IdVehiculo);
        Task<Vehiculo> CreateVehiculo(string MarcaVehiculo, string ModeloVehiculo, string PlacaVehiculo, int IdTipoVehiculo);
        Task<Vehiculo> UpdateVehiculo(
         int IdVehiculo,
         string? MarcaVehiculo = null,
         string? ModeloVehiculo = null,
         string? PlacaVehiculo = null,
          int? IdTipoVehiculo = null
       );
        Task<Vehiculo> DeleteVehiculo(int IdVehiculo);
    }
    public class VehiculoService: IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<List<Vehiculo>> GetAll()
        {
            return await _vehiculoRepository.GetAll();
        }

        public async Task<Vehiculo> GetVehiculo(int IdVehiculo)
        {
            return await _vehiculoRepository.GetVehiculo(IdVehiculo);
        }

        public async Task<Vehiculo> CreateVehiculo(string MarcaVehiculo, string ModeloVehiculo, string PlacaVehiculo, int IdTipoVehiculo)
        {
            return await _vehiculoRepository.CreateVehiculo(MarcaVehiculo, ModeloVehiculo, PlacaVehiculo, IdTipoVehiculo);
        }

        public async Task<Vehiculo> UpdateVehiculo(
            int IdVehiculo,
            string? MarcaVehiculo = null,
            string? ModeloVehiculo = null,
            string? PlacaVehiculo = null,
            int? IdTipoVehiculo = null
          )
        {
            var vehiculo = await _vehiculoRepository.GetVehiculo(IdVehiculo);
            if (vehiculo == null)
            {
                throw new Exception("Vehiculo not found");
            }

            if (MarcaVehiculo != null)
            {
                vehiculo.MarcaVehiculo = MarcaVehiculo;
            }
            if (ModeloVehiculo != null)
            {
                vehiculo.ModeloVehiculo = ModeloVehiculo;
            }
            if (PlacaVehiculo != null)
            {
                vehiculo.PlacaVehiculo = PlacaVehiculo;
            }
            if (IdTipoVehiculo != null)
            {
                vehiculo.IdTipoVehiculo = (int)IdTipoVehiculo;
            }

            return await _vehiculoRepository.UpdateVehiculo(vehiculo);
        }

        public async Task<Vehiculo> DeleteVehiculo(int IdVehiculo)
        {
            return await _vehiculoRepository.DeleteVehiculo(IdVehiculo);
        }
    }
}

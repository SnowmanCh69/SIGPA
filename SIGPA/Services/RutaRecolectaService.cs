using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IRutaRecolectaService
    {

        Task<List<RutaRecolecta>> GetAll();
        Task<RutaRecolecta> GetRutaRecolecta(int IdRutaRecolecta);
        Task<RutaRecolecta> CreateRutaRecolecta(string PuntoInicio, string PuntoFinalizacion, int IdEstadoRuta, int IdUsuario, int IdVehiculo);
        
        Task<RutaRecolecta> UpdateRutaRecolecta(
         int IdRutaRecolecta,
         string? PuntoInicio = null,
         string? PuntoFinalizacion = null,
         int? IdEstadoRuta = null,
         int? IdUsuario = null,
         int? IdVehiculo = null
      );
    }
    public class RutaRecolectaService : IRutaRecolectaService
    {
        private readonly IRutaRecolectaRepository _rutaRecolectaRepository;
        public RutaRecolectaService(IRutaRecolectaRepository rutaRecolectaRepository)
        {
            _rutaRecolectaRepository = rutaRecolectaRepository;
        }

        public async Task<List<RutaRecolecta>> GetAll()
        {
            return await _rutaRecolectaRepository.GetAll();
        }

        public async Task<RutaRecolecta> GetRutaRecolecta(int IdRutaRecolecta)
        {
            return await _rutaRecolectaRepository.GetRutaRecolecta(IdRutaRecolecta);
        }

        public async Task<RutaRecolecta> CreateRutaRecolecta(string PuntoInicio, string PuntoFinalizacion, int IdEstadoRuta, int IdUsuario, int IdVehiculo)
        {
            return await _rutaRecolectaRepository.CreateRutaRecolecta(PuntoInicio, PuntoFinalizacion, IdEstadoRuta, IdUsuario, IdVehiculo);
        }

        public async Task<RutaRecolecta> UpdateRutaRecolecta(
           int IdRutaRecolecta,
           string? PuntoInicio = null,
           string? PuntoFinalizacion = null,
           int? IdEstadoRuta = null,
           int? IdUsuario = null,
           int? IdVehiculo = null
          )
        {
            var rutaRecolecta = await _rutaRecolectaRepository.GetRutaRecolecta(IdRutaRecolecta);
            if (rutaRecolecta == null)
            {
                throw new Exception("RutaRecolecta not found");
            }

            if (PuntoInicio != null)
            {
                rutaRecolecta.PuntoInicio = PuntoInicio;
            }
            if (PuntoFinalizacion != null)
            {
                rutaRecolecta.PuntoFinalizacion = PuntoFinalizacion;
            }
            if (IdEstadoRuta != null)
            {
                rutaRecolecta.IdEstadoRuta = (int)IdEstadoRuta;
            }
            if (IdUsuario != null)
            {
                rutaRecolecta.IdUsuario = (int)IdUsuario;
            }
            if (IdVehiculo != null)
            {
                rutaRecolecta.IdVehiculo = (int)IdVehiculo;
            }

            return await _rutaRecolectaRepository.UpdateRutaRecolecta(rutaRecolecta);
            
        }

        public async Task<RutaRecolecta> DeleteRutaRecolecta(int IdRutaRecolecta)
        {
            return await _rutaRecolectaRepository.DeleteRutaRecolecta(IdRutaRecolecta);
        }
    }
    
}

using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IRutaRecolectaService
    {
        Task<IEnumerable<RutaRecolecta>> GetRutasRecolecta();
        Task<RutaRecolecta?> GetRutaRecolecta(int id);
        Task<RutaRecolecta> CreateRutaRecolecta(
          string PuntoInicio,
          string PuntoFinalizacion,
          int IdEstadoRuta,
          int IdUsuario,
          int IdVehiculo
        );
        Task<RutaRecolecta> UpdateRutaRecolecta(
          int IdRutaRecolecta,
          string? PuntoInicio,
          string? PuntoFinalizacion,
          int? IdEstadoRuta,
          int? IdUsuario,
          int? IdVehiculo
        );

    }
    public class RutaRecolectaService(IRutaRecolectaRepository rutaRecolectaRepository) : IRutaRecolectaService
    {

        public async Task<RutaRecolecta?> GetRutaRecolecta(int id)
        {
            return await rutaRecolectaRepository.GetRutaRecolecta(id);
        }

        public async Task<IEnumerable<RutaRecolecta>> GetRutasRecolecta()
        {
            return await rutaRecolectaRepository.GetRutasRecolecta();
        }

        public async Task<RutaRecolecta> CreateRutaRecolecta(
           string PuntoInicio,
           string PuntoFinalizacion,
           int IdEstadoRuta,
           int IdUsuario,
           int IdVehiculo
         )
        {
            return await rutaRecolectaRepository.CreateRutaRecolecta(new RutaRecolecta
            {
                PuntoInicio = PuntoInicio,
                PuntoFinalizacion = PuntoFinalizacion,
                IdEstadoRuta = IdEstadoRuta,
                IdUsuario = IdUsuario,
                IdVehiculo = IdVehiculo
            });
        }

        public async Task<RutaRecolecta> UpdateRutaRecolecta(
           int IdRutaRecolecta,
           string? PuntoInicio,
           string? PuntoFinalizacion,
           int? IdEstadoRuta,
           int? IdUsuario,
           int? IdVehiculo
          )
        {
            RutaRecolecta? rutaRecolecta = await rutaRecolectaRepository.GetRutaRecolecta(IdRutaRecolecta);
            if (rutaRecolecta == null) throw new Exception("RutaRecolecta not found");
            rutaRecolecta.PuntoInicio = PuntoInicio ?? rutaRecolecta.PuntoInicio;
            rutaRecolecta.PuntoFinalizacion = PuntoFinalizacion ?? rutaRecolecta.PuntoFinalizacion;
            rutaRecolecta.IdEstadoRuta = IdEstadoRuta ?? rutaRecolecta.IdEstadoRuta;
            rutaRecolecta.IdUsuario = IdUsuario ?? rutaRecolecta.IdUsuario;
            rutaRecolecta.IdVehiculo = IdVehiculo ?? rutaRecolecta.IdVehiculo;
            return await rutaRecolectaRepository.UpdateRutaRecolecta(rutaRecolecta);
            
        }
    }
}

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
          int IdVehiculo,
          int IdResiduo,
          DateOnly FechaRecoleccion
        );
        Task<RutaRecolecta> UpdateRutaRecolecta(
          int IdRutaRecolecta,
          string? PuntoInicio,
          string? PuntoFinalizacion,
          int? IdEstadoRuta,
          int? IdUsuario,
          int? IdVehiculo,
          int? IdResiduo,
          DateOnly? FechaRecoleccion
        );
        Task<RutaRecolecta?> DeleteRutaRecolecta(int id);



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
           int IdVehiculo,
           int IdResiduo,
           DateOnly FechaRecoleccion
         )
        {
            return await rutaRecolectaRepository.CreateRutaRecolecta(new RutaRecolecta
            {
                PuntoInicio = PuntoInicio,
                PuntoFinalizacion = PuntoFinalizacion,
                IdEstadoRuta = IdEstadoRuta,
                IdUsuario = IdUsuario,
                IdVehiculo = IdVehiculo,
                IdResiduo = IdResiduo,
                FechaRecoleccion = FechaRecoleccion
                
            });
        }

        public async Task<RutaRecolecta> UpdateRutaRecolecta(
           int IdRutaRecolecta,
           string? PuntoInicio,
           string? PuntoFinalizacion,
           int? IdEstadoRuta,
           int? IdUsuario,
           int? IdVehiculo,
           int? IdResiduo,
           DateOnly? FechaRecoleccion
          )
        {
            RutaRecolecta? rutaRecolecta = await rutaRecolectaRepository.GetRutaRecolecta(IdRutaRecolecta);
            if (rutaRecolecta == null) throw new Exception("RutaRecolecta not found");
            rutaRecolecta.PuntoInicio = PuntoInicio ?? rutaRecolecta.PuntoInicio;
            rutaRecolecta.PuntoFinalizacion = PuntoFinalizacion ?? rutaRecolecta.PuntoFinalizacion;
            rutaRecolecta.IdEstadoRuta = IdEstadoRuta ?? rutaRecolecta.IdEstadoRuta;
            rutaRecolecta.IdUsuario = IdUsuario ?? rutaRecolecta.IdUsuario;
            rutaRecolecta.IdVehiculo = IdVehiculo ?? rutaRecolecta.IdVehiculo;
            rutaRecolecta.IdResiduo = IdResiduo ?? rutaRecolecta.IdResiduo;
            rutaRecolecta.FechaRecoleccion = FechaRecoleccion ?? rutaRecolecta.FechaRecoleccion;
            
            return await rutaRecolectaRepository.UpdateRutaRecolecta(rutaRecolecta);
            
        }

        public async Task<RutaRecolecta?> DeleteRutaRecolecta(int id)
        {
            return await rutaRecolectaRepository.DeleteRutaRecolecta(id);
        }
    }
}

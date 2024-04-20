using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IRecolectaControlCalidadService
    {
        Task<IEnumerable<RecolectaControlCalidad>> GetRecolectasControlesCalidad();
        Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int id);
        Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(
           int IdControlCalidad,
           int IdResultado,
           string Observaciones
                    );
        Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(
           int IdRecolectaControlCalidad,
           int? IdControlCalidad,
           int? IdResultado,
           string? Observaciones
         );
        Task<RecolectaControlCalidad?> DeleteRecolectaControlCalidad(int id);
    }
    public class RecolectaControlCalidadService(IRecolectaControlCalidadRepository recolectaControlCalidadRepository): IRecolectaControlCalidadService
    {
        
        public async Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int id)
        {
            return await recolectaControlCalidadRepository.GetRecolectaControlCalidad(id);
        }

        public async Task<IEnumerable<RecolectaControlCalidad>> GetRecolectasControlesCalidad()
        {
            return await recolectaControlCalidadRepository.GetRecolectasControlCalidad();
        }

        public async Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(
           int IdControlCalidad,
           int IdResultado,
           string Observaciones
         )
        {
            return await recolectaControlCalidadRepository.CreateRecolectaControlCalidad(new RecolectaControlCalidad
            {
                IdControlCalidad = IdControlCalidad,
                IdResultado = IdResultado,
                Observaciones = Observaciones
            });
        }

        public async Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(
              int IdRecolectaControlCalidad,
              int? IdControlCalidad,
              int? IdResultado,
              string? Observaciones
         )
        {
            RecolectaControlCalidad? recolectaControlCalidad = await recolectaControlCalidadRepository.GetRecolectaControlCalidad(IdRecolectaControlCalidad);
            if (recolectaControlCalidad == null) throw new Exception("RecolectaControlCalidad not found");
            recolectaControlCalidad.IdControlCalidad = IdControlCalidad ?? recolectaControlCalidad.IdControlCalidad;
            recolectaControlCalidad.IdResultado = IdResultado ?? recolectaControlCalidad.IdResultado;
            recolectaControlCalidad.Observaciones = Observaciones ?? recolectaControlCalidad.Observaciones;
            return await recolectaControlCalidadRepository.UpdateRecolectaControlCalidad(recolectaControlCalidad);
        }

        public async Task<RecolectaControlCalidad?> DeleteRecolectaControlCalidad(int id)
        {
            return await recolectaControlCalidadRepository.DeleteRecolectaControlCalidad(id);
        }
    }
    
}

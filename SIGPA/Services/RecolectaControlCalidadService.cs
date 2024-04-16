using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IRecolectaControlCalidadService
    {
        Task<List<RecolectaControlCalidad>> GetAll();
        Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int IdRecolectaControlCalidad);
        Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(int IdControlCalidad, int IdResultado , string Observaciones);
        Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(
         int IdRecolectaControlCalidad,
         int? IdResultadp = null,
         string? Observaciones = null
         );
        Task<RecolectaControlCalidad> DeleteRecolectaControlCalidad(int idRecolectaControlCalidad);
    }
    public class RecolectaControlCalidadService : IRecolectaControlCalidadService
    {
        private readonly IRecolectaControlCalidadRepository _recolectaControlCalidadRepository;
        public RecolectaControlCalidadService(IRecolectaControlCalidadRepository recolectaControlCalidadRepository)
        {
            _recolectaControlCalidadRepository = recolectaControlCalidadRepository;
        }

        public async Task<List<RecolectaControlCalidad>> GetAll()
        {
            return await _recolectaControlCalidadRepository.GetAll();
        }

        public async Task<RecolectaControlCalidad?> GetRecolectaControlCalidad(int IdRecolectaControlCalidad)
        {
            return await _recolectaControlCalidadRepository.GetRecolectaControlCalidad(IdRecolectaControlCalidad);
        }

        public async Task<RecolectaControlCalidad> CreateRecolectaControlCalidad(int IdControlCalidad, int IdResultado, string Observaciones)
        {
            return await _recolectaControlCalidadRepository.CreateRecolectaControlCalidad(IdControlCalidad, IdResultado, Observaciones);
        }

        public async Task<RecolectaControlCalidad> UpdateRecolectaControlCalidad(
           int IdRecolectaControlCalidad,
           int? IdResultado = null,
           string? Observaciones = null
         )
        {
            var recolectaControlCalidad = await _recolectaControlCalidadRepository.GetRecolectaControlCalidad(IdRecolectaControlCalidad);
            if (recolectaControlCalidad == null)
            {
                throw new Exception("RecolectaControlCalidad not found");
            }

            if (IdResultado != null)
            {
                recolectaControlCalidad.IdResultado = (int)IdResultado;

            }

            if (Observaciones != null)
            {
                recolectaControlCalidad.Observaciones = Observaciones;

            }

            return await _recolectaControlCalidadRepository.UpdateRecolectaControlCalidad(recolectaControlCalidad);
        }

        public async Task<RecolectaControlCalidad> DeleteRecolectaControlCalidad(int idRecolectaControlCalidad)
        {
            return await _recolectaControlCalidadRepository.DeleteRecolectaControlCalidad(idRecolectaControlCalidad);
        }
    }
    
}

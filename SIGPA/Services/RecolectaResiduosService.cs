using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    public interface IRecolectaResiduosService
    {
        Task<List<RecolectaResiduos>> GetAll();
        Task<RecolectaResiduos?> GetRecolectaResiduos(int IdRecolectaResiduos);
        Task<RecolectaResiduos> CreateRecolectaResiduos(int IdRutaRecolecta, int IdResiduos, int IdUsuario, string CantidadRecolectada, DateTime FechaRecoleccion);
        Task<RecolectaResiduos> UpdateRecolectaResiduos(
          int IdRecolectaResiduos,
          int? IdRutaRecolecta = null,
          int? IdResiduos = null,
          int? IdUsuario = null,
          string? CantidadRecolectada = null,
          DateTime? FechaRecoleccion = null
                   );
        Task<RecolectaResiduos> DeleteRecolectaResiduos(int idRecolectaResiduos);
    }
    public class RecolectaResiduosService : IRecolectaResiduosService
    {
        private readonly IRecolectaResiduosRepository _recolectaResiduosRepository;
        public RecolectaResiduosService(IRecolectaResiduosRepository recolectaResiduosRepository)
        {
            _recolectaResiduosRepository = recolectaResiduosRepository;
        }

        public async Task<List<RecolectaResiduos>> GetAll()
        {
            return await _recolectaResiduosRepository.GetAll();
        }

        public async Task<RecolectaResiduos?> GetRecolectaResiduos(int IdRecolectaResiduos)
        {
            return await _recolectaResiduosRepository.GetRecolectaResiduos(IdRecolectaResiduos);
        }

        public async Task<RecolectaResiduos> CreateRecolectaResiduos(int IdRutaRecolecta, int IdResiduos, int IdUsuario, string CantidadRecolectada, DateTime FechaRecoleccion)
        {
            return await _recolectaResiduosRepository.CreateRecolectaResiduos(IdRutaRecolecta, IdResiduos, IdUsuario, CantidadRecolectada, FechaRecoleccion);
        }

        public async Task<RecolectaResiduos> UpdateRecolectaResiduos(
           int IdRecolectaResiduos,
           int? IdRutaRecolecta = null,
           int? IdResiduos = null,
           int? IdUsuario = null,
           string? CantidadRecolectada = null,
           DateTime? FechaRecoleccion = null
         )
        {
            var recolectaResiduos = await _recolectaResiduosRepository.GetRecolectaResiduos(IdRecolectaResiduos);
            if (recolectaResiduos == null)
            {
                throw new Exception("RecolectaResiduos not found");
            }

            if (IdRutaRecolecta != null)
            {
                recolectaResiduos.IdRutaRecolecta = (int)IdRutaRecolecta;

            }

            if (IdResiduos != null)
            {
                recolectaResiduos.IdResiduos = (int)IdResiduos;
            }

            if (IdUsuario != null)
            {
                recolectaResiduos.IdUsuario = (int)IdUsuario;
            }

            if (CantidadRecolectada != null)
            {
                recolectaResiduos.CantidadRecolectada = (string)CantidadRecolectada;
            }

            if (FechaRecoleccion != null)
            {
                recolectaResiduos.FechaRecoleccion = (DateTime)FechaRecoleccion;
            }

                return await _recolectaResiduosRepository.UpdateRecolectaResiduos(recolectaResiduos);
  
        }

        public async Task<RecolectaResiduos> DeleteRecolectaResiduos(int idRecolectaResiduos)
        {
            return await _recolectaResiduosRepository.DeleteRecolectaResiduos(idRecolectaResiduos);
        }
    }
    
}

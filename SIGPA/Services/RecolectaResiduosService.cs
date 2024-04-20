using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    public interface IRecolectaResiduosService
    {
        Task<IEnumerable<RecolectaResiduos>> GetRecolectasResiduos();
        Task<RecolectaResiduos?> GetRecolectaResiduos(int id);
        Task<RecolectaResiduos> CreateRecolectaResiduos(
           int IdRutaRecolecta,
           int IdResiduo,
           int IdUsuario,
           string CantidadRecolectada,
           DateTime FechaRecoleccion
         );

        Task<RecolectaResiduos> UpdateRecolectaResiduos(
         int IdRecolectaResiduos,
         int? IdRutaRecolecta,
         int? IdResiduo,
         int? IdUsuario,
         string? CantidadRecolectada,
         DateTime? FechaRecoleccion
       );

        Task<RecolectaResiduos?> DeleteRecolectaResiduos(int id);
    }

    public class RecolectaResiduosService(IRecolectaResiduosRepository recolectaResiduosRepository) : IRecolectaResiduosService
    {

        public async Task<RecolectaResiduos?> GetRecolectaResiduos(int id)
        {
            return await recolectaResiduosRepository.GetRecolectaResiduos(id);
        }

        public async Task<IEnumerable<RecolectaResiduos>> GetRecolectasResiduos()
        {
            return await recolectaResiduosRepository.GetRecolectasResiduos();
        }

        public async Task<RecolectaResiduos> CreateRecolectaResiduos(
           int IdRutaRecolecta,
           int IdResiduo,
           int IdUsuario,
           string CantidadRecolectada,
           DateTime FechaRecoleccion
         )
        {
            return await recolectaResiduosRepository.CreateRecolectaResiduos(new RecolectaResiduos
            {
                IdRutaRecolecta = IdRutaRecolecta,
                IdResiduo = IdResiduo,
                IdUsuario = IdUsuario,
                CantidadRecolectada = CantidadRecolectada,
                FechaRecoleccion = FechaRecoleccion
            });
        }

        public async Task<RecolectaResiduos> UpdateRecolectaResiduos(
            int IdRecolectaResiduos,
            int? IdRutaRecolecta,
            int? IdResiduo,
            int? IdUsuario,
            string? CantidadRecolectada,
             DateTime? FechaRecoleccion
         )
        {
            RecolectaResiduos? recolectaResiduos = await recolectaResiduosRepository.GetRecolectaResiduos(IdRecolectaResiduos);
            if (recolectaResiduos == null) throw new Exception("RecolectaResiduos not found");
            recolectaResiduos.IdRutaRecolecta = IdRutaRecolecta ?? recolectaResiduos.IdRutaRecolecta;
            recolectaResiduos.IdResiduo = IdResiduo ?? recolectaResiduos.IdResiduo;
            recolectaResiduos.IdUsuario = IdUsuario ?? recolectaResiduos.IdUsuario;
            recolectaResiduos.CantidadRecolectada = CantidadRecolectada ?? recolectaResiduos.CantidadRecolectada;
            recolectaResiduos.FechaRecoleccion = FechaRecoleccion ?? recolectaResiduos.FechaRecoleccion;
            return await recolectaResiduosRepository.UpdateRecolectaResiduos(recolectaResiduos);
            
        }

        public async Task<RecolectaResiduos?> DeleteRecolectaResiduos(int id)
        {
            return await recolectaResiduosRepository.DeleteRecolectaResiduos(id);
        }
    }

}
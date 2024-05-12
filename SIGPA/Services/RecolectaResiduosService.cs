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
           int IdResiduo
         );

        Task<RecolectaResiduos> UpdateRecolectaResiduos(
         int IdRecolectaResiduos,
         int? IdRutaRecolecta,
         int? IdResiduo
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
           int IdResiduo
         )
        {
            return await recolectaResiduosRepository.CreateRecolectaResiduos(new RecolectaResiduos
            {
                IdRutaRecolecta = IdRutaRecolecta,
                IdResiduo = IdResiduo
            });
        }

        public async Task<RecolectaResiduos> UpdateRecolectaResiduos(
            int IdRecolectaResiduos,
            int? IdRutaRecolecta,
            int? IdResiduo
         )
        {
            RecolectaResiduos? recolectaResiduos = await recolectaResiduosRepository.GetRecolectaResiduos(IdRecolectaResiduos);
            if (recolectaResiduos == null) throw new Exception("RecolectaResiduos not found");
            recolectaResiduos.IdRutaRecolecta = IdRutaRecolecta ?? recolectaResiduos.IdRutaRecolecta;
            recolectaResiduos.IdResiduo = IdResiduo ?? recolectaResiduos.IdResiduo;
            return await recolectaResiduosRepository.UpdateRecolectaResiduos(recolectaResiduos);
            
        }

        public async Task<RecolectaResiduos?> DeleteRecolectaResiduos(int id)
        {
            return await recolectaResiduosRepository.DeleteRecolectaResiduos(id);
        }
    }

}
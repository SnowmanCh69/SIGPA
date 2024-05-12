using SIGPA.Models;
using SIGPA.Repositories;


namespace SIGPA.Services
{
    public interface IResiduosPartidaService
    {
        Task<IEnumerable<ResiduosPartida>> GetResiduosPartida();
        Task<ResiduosPartida?> GetResiduoPartida(int id);
        Task<ResiduosPartida> CreateResiduoPartida(
          int IdPartida,
          int IdResiduo
        );
        Task<ResiduosPartida> UpdateResiduoPartida(
          int IdResiduoPartida,
          int? IdPartida,
          int? IdResiduo
        );
        Task<ResiduosPartida?> DeleteResiduoPartida(int id);
       

    }
    public class ResiduosPartidaService(IResiduosPartidaRepository residuosPartidaRepository) : IResiduosPartidaService
    {

        public async Task<ResiduosPartida?> GetResiduoPartida(int id)
        {
            return await residuosPartidaRepository.GetResiduoPartida(id);
        }

        public async Task<IEnumerable<ResiduosPartida>> GetResiduosPartida()
        {
            return await residuosPartidaRepository.GetResiduosPartida();
        }

        public async Task<ResiduosPartida> CreateResiduoPartida(
           int IdPartida,
           int IdResiduo
          )
        {
            return await residuosPartidaRepository.CreateResiduoPartida(new ResiduosPartida
            {
                IdPartida = IdPartida,
                IdResiduo = IdResiduo
            });
        }

        public async Task<ResiduosPartida> UpdateResiduoPartida(
           int IdResiduoPartida,
           int? IdPartida,
           int? IdResiduo
          )
        {
            ResiduosPartida? residuosPartida = await residuosPartidaRepository.GetResiduoPartida(IdResiduoPartida);
            if (residuosPartida == null) throw new Exception("ResiduoPartida not found");
            residuosPartida.IdPartida = IdPartida ?? residuosPartida.IdPartida;
            residuosPartida.IdResiduo = IdResiduo ?? residuosPartida.IdResiduo;
            return await residuosPartidaRepository.UpdateResiduoPartida(residuosPartida);
        }

        public async Task<ResiduosPartida?> DeleteResiduoPartida(int id)
        {
            return await residuosPartidaRepository.DeleteResiduoPartida(id);
        }
    }
}

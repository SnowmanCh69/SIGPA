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
          int IdResiduo,
          string CantidadRegistrada
        );
        Task<ResiduosPartida> UpdateResiduoPartida(
          int IdResiduoPartida,
          int? IdPartida,
          int? IdResiduo,
          string? CantidadRegistrada
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
           int IdResiduo,
           string CantidadRegistrada
          )
        {
            return await residuosPartidaRepository.CreateResiduoPartida(new ResiduosPartida
            {
                IdPartida = IdPartida,
                IdResiduo = IdResiduo,
                CantidadRegistrada = CantidadRegistrada
            });
        }

        public async Task<ResiduosPartida> UpdateResiduoPartida(
           int IdResiduoPartida,
           int? IdPartida,
           int? IdResiduo,
           string? CantidadRegistrada
          )
        {
            ResiduosPartida? residuosPartida = await residuosPartidaRepository.GetResiduoPartida(IdResiduoPartida);
            if (residuosPartida == null) throw new Exception("ResiduoPartida not found");
            residuosPartida.IdPartida = IdPartida ?? residuosPartida.IdPartida;
            residuosPartida.IdResiduo = IdResiduo ?? residuosPartida.IdResiduo;
            residuosPartida.CantidadRegistrada = CantidadRegistrada ?? residuosPartida.CantidadRegistrada;
            return await residuosPartidaRepository.UpdateResiduoPartida(residuosPartida);
        }

        public async Task<ResiduosPartida?> DeleteResiduoPartida(int id)
        {
            return await residuosPartidaRepository.DeleteResiduoPartida(id);
        }
    }
}

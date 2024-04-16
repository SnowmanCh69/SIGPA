using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IResiduosPartidaService
    {
        Task<List<ResiduosPartida>> GetAll();
        Task<ResiduosPartida> GetResiduosPartida(int IdResiduosPartida);
        Task<ResiduosPartida> CreateResiduosPartida(int IdPartida, int IdResiduos, string CantidadRegistrada);
        Task<ResiduosPartida> UpdateResiduosPartida(
          int IdResiduosPartida,
          int? IdPartida = null,
          int? IdResiduos = null,
          string? CantidadRegistrada = null
     );
        Task<ResiduosPartida> DeleteResiduosPartida(int idResiduosPartida);
    }
    public class ResiduosPartidaService : IResiduosPartidaService
    {
        private readonly IResiduosPartidaRepository _residuosPartidaRepository;
        public ResiduosPartidaService(IResiduosPartidaRepository residuosPartidaRepository)
        {
            _residuosPartidaRepository = residuosPartidaRepository;
        }

        public async Task<List<ResiduosPartida>> GetAll()
        {
            return await _residuosPartidaRepository.GetAll();
        }

        public async Task<ResiduosPartida> GetResiduosPartida(int IdResiduosPartida)
        {
            return await _residuosPartidaRepository.GetResiduosPartida(IdResiduosPartida);
        }

        public async Task<ResiduosPartida> CreateResiduosPartida(int IdPartida, int IdResiduos, string CantidadRegistrada)
        {
            return await _residuosPartidaRepository.CreateResiduosPartida(IdPartida, IdResiduos, CantidadRegistrada);
        }

        public async Task<ResiduosPartida> UpdateResiduosPartida(
                       int IdResiduosPartida,
                                  int? IdPartida = null,
                                             int? IdResiduos = null,
                                                        string? CantidadRegistrada = null
                   )
        {
            var residuosPartida = await _residuosPartidaRepository.GetResiduosPartida(IdResiduosPartida);
            if (residuosPartida == null)
            {
                throw new Exception("ResiduosPartida not found");
            }

            if (IdPartida != null)
            {
                residuosPartida.IdPartida = (int)IdPartida;
            }
            if (IdResiduos != null)
            {
                residuosPartida.IdResiduos = (int)IdResiduos;
            }
            if (CantidadRegistrada != null)
            {
                residuosPartida.CantidadRegistrada = CantidadRegistrada;
            }

            return await _residuosPartidaRepository.UpdateResiduosPartida(residuosPartida);
        }

        public async Task<ResiduosPartida> DeleteResiduosPartida(int idResiduosPartida)
        {
            return await _residuosPartidaRepository.DeleteResiduosPartida(idResiduosPartida);
        }
    }
   
}

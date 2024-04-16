using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface ITipoResiduosService
    {
        Task<List<TipoResiduos>> GetAll();
        Task<TipoResiduos> GetTipoResiduos(int IdTipoResiduos);
        Task<TipoResiduos> CreateTipoResiduos(string NombreTipoResiduos);
        Task<TipoResiduos> UpdateTipoResiduos(
         int IdTipoResiduos,
         string? NombreTipoResiduos = null
          );
        Task<TipoResiduos> DeleteTipoResiduos(int IdTipoResiduos);
    }
    public class TipoResiduosService : ITipoResiduosService
    {
        private readonly ITipoResiduosRepository _tipoResiduosRepository;
        public TipoResiduosService(ITipoResiduosRepository tipoResiduosRepository)
        {
            _tipoResiduosRepository = tipoResiduosRepository;
        }

        public async Task<List<TipoResiduos>> GetAll()
        {
            return await _tipoResiduosRepository.GetAll();
        }

        public async Task<TipoResiduos> GetTipoResiduos(int IdTipoResiduos)
        {
            return await _tipoResiduosRepository.GetTipoResiduos(IdTipoResiduos);
        }

        public async Task<TipoResiduos> CreateTipoResiduos(string NombreTipoResiduos)
        {
            return await _tipoResiduosRepository.CreateTipoResiduos(NombreTipoResiduos);
        }

        public async Task<TipoResiduos> UpdateTipoResiduos(
           int IdTipoResiduos,
           string? NombreTipoResiduos = null
         )
        {
            var tipoResiduos = await _tipoResiduosRepository.GetTipoResiduos(IdTipoResiduos);
            if (tipoResiduos == null)
            {
                throw new Exception("TipoResiduos not found");
            }

            if (NombreTipoResiduos != null)
            {
                tipoResiduos.NombreTipoResiduos = NombreTipoResiduos;
            }

            return await _tipoResiduosRepository.UpdateTipoResiduos(tipoResiduos);
        }

        public async Task<TipoResiduos> DeleteTipoResiduos(int IdTipoResiduos)
        {

            return await _tipoResiduosRepository.DeleteTipoResiduos(IdTipoResiduos);
        }
    }
}

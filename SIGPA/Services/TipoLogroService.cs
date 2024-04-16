using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    interface ITipoLogroService
    {
        Task<List<TipoLogro>> GetAll();
        Task<TipoLogro> GetTipoLogro(int IdTipoLogro);
        Task<TipoLogro> CreateTipoLogro(string NombreTipoLogro);
        Task<TipoLogro> UpdateTipoLogro(
            int IdTipoLogro,
            string? NombreTipoLogro = null
       );
        Task<TipoLogro> DeleteTipoLogro(int IdTipoLogro);
    }
    public class TipoLogroService  : ITipoLogroService
    {
        private readonly ITipoLogroRepository _tipoLogroRepository;
        public TipoLogroService(ITipoLogroRepository tipoLogroRepository)
        {
            _tipoLogroRepository = tipoLogroRepository;
        }

        public async Task<List<TipoLogro>> GetAll()
        {
            return await _tipoLogroRepository.GetAll();
        }

        public async Task<TipoLogro> GetTipoLogro(int IdTipoLogro)
        {
            return await _tipoLogroRepository.GetTipoLogro(IdTipoLogro);
        }

        public async Task<TipoLogro> CreateTipoLogro(string NombreTipoLogro)
        {
            return await _tipoLogroRepository.CreateTipoLogro(NombreTipoLogro);
        }

        public async Task<TipoLogro> UpdateTipoLogro(
          int IdTipoLogro,
           string? NombreTipoLogro = null
         )
        {
            var tipoLogro = await _tipoLogroRepository.GetTipoLogro(IdTipoLogro);
            if (tipoLogro == null)
            {
                throw new Exception("TipoLogro not found");
            }

            if (NombreTipoLogro != null)
            {
                tipoLogro.NombreTipoLogro = NombreTipoLogro;
            }

            return await _tipoLogroRepository.UpdateTipoLogro(tipoLogro);
        }

        public async Task<TipoLogro> DeleteTipoLogro(int IdTipoLogro)
        {

            return await _tipoLogroRepository.DeleteTipoLogro(IdTipoLogro);
        }
    }
    
}

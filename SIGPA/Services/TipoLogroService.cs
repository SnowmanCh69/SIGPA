using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface ITipoLogroService
    {
        Task<IEnumerable<TipoLogro>> GetTipoLogros();
        Task<TipoLogro?> GetTipoLogro(int id);
        Task<TipoLogro> CreateTipoLogro(
          string NombreTipoLogro
        );
        Task<TipoLogro> UpdateTipoLogro(
           int IdTipoLogro,
           string? NombreTipoLogro
        );
        Task<TipoLogro> DeleteTipoLogro(int id);
    }
    public class TipoLogroService(ITipoLogroRepository tipoLogroRepository) : ITipoLogroService
    {
        public async Task<TipoLogro?> GetTipoLogro(int id)
        {
            return await tipoLogroRepository.GetTipoLogro(id);
        }

        public async Task<IEnumerable<TipoLogro>> GetTipoLogros()
        {
            return await tipoLogroRepository.GetTiposLogros();
        }

        public async Task<TipoLogro> CreateTipoLogro(
           string NombreTipoLogro
         )
        {
            return await tipoLogroRepository.CreateTipoLogro(new TipoLogro
            {
                NombreTipoLogro = NombreTipoLogro
            });
        }

        public async Task<TipoLogro> UpdateTipoLogro(
          int IdTipoLogro,
           string? NombreTipoLogro
         )
        {
            TipoLogro? tipoLogro = await tipoLogroRepository.GetTipoLogro(IdTipoLogro);
            if (tipoLogro == null) throw new Exception("TipoLogro not found");
            tipoLogro.NombreTipoLogro = NombreTipoLogro ?? tipoLogro.NombreTipoLogro;
            return await tipoLogroRepository.UpdateTipoLogro(tipoLogro);
        }

        public async Task<TipoLogro> DeleteTipoLogro(int id)
        {
            return await tipoLogroRepository.DeleteTipoLogro(id);
        }
    }

}

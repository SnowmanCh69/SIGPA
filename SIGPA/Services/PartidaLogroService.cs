using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IPartidaLogroService
    {
        Task<List<PartidaLogro>> GetAll();
        Task<PartidaLogro?> GetPartidaLogro(int IdPartidaLogro);
        Task<PartidaLogro> CreatePartidaLogro(int IdPartida, int IdLogro, DateTime FechaLogro);
        Task<PartidaLogro> UpdatePartidaLogro(
          int IdPartidaLogro,
          int? IdPartida = null,
          int? IdLogro = null,
          DateTime? FechaLogro = null
        );
        Task<PartidaLogro> DeletePartidaLogro(int idPartidaLogro);
    }
    public class PartidaLogroService: IPartidaLogroService
    {
        private readonly IPartidaLogroRepository _partidaLogroRepository;
        public PartidaLogroService(IPartidaLogroRepository partidaLogroRepository)
        {
            _partidaLogroRepository = partidaLogroRepository;
        }

        public async Task<List<PartidaLogro>> GetAll()
        {
            return await _partidaLogroRepository.GetAll();
        }

        public async Task<PartidaLogro?> GetPartidaLogro(int IdPartidaLogro)
        {
            return await _partidaLogroRepository.GetPartidaLogro(IdPartidaLogro);
        }

        public async Task<PartidaLogro> CreatePartidaLogro(int IdPartida, int IdLogro, DateTime FechaLogro)
        {
            return await _partidaLogroRepository.CreatePartidaLogro(IdPartida, IdLogro, FechaLogro);
        }

        public async Task<PartidaLogro> UpdatePartidaLogro(
           int IdPartidaLogro,
           int? IdPartida = null,
           int? IdLogro = null,
           DateTime? FechaLogro = null
         )
        {
            var partidaLogro = await _partidaLogroRepository.GetPartidaLogro(IdPartidaLogro);
            if (partidaLogro == null)
            {
                throw new Exception("PartidaLogro not found");
            }

            if(IdPartida!= null)
            {
                partidaLogro.IdPartida = (int)IdPartida;

            }

            if(IdLogro!= null)
            {
                partidaLogro.IdLogro = (int)IdLogro;
            }

            if(FechaLogro!= null)
            {
                partidaLogro.FechaLogro = (DateTime)FechaLogro;
            }

            return await _partidaLogroRepository.UpdatePartidaLogro(partidaLogro);
        }

        public async Task<PartidaLogro> DeletePartidaLogro(int idPartidaLogro)
        {
            return await _partidaLogroRepository.DeletePartidaLogro(idPartidaLogro);
        }
    }
    
}

using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IPartidaLogroService
    {
        Task<IEnumerable<PartidaLogro>> GetPartidasLogros();
        Task<PartidaLogro?> GetPartidaLogro(int id);
        Task<PartidaLogro> CreatePartidaLogro(
         int IdPartida,
         int IdLogro,
         DateTime FechaLogro

        );
        Task<PartidaLogro> UpdatePartidaLogro(
          int IdPartidaLogro,
          int? IdPartida,
          int? IdLogro,
          DateTime? FechaLogro
        );
        Task<PartidaLogro> DeletePartidaLogro(int id);
    }
    public class PartidaLogroService(IPartidaLogroRepository partidaLogroRepository) : IPartidaLogroService
    {
        
        public async Task<PartidaLogro?> GetPartidaLogro(int id)
        {
            return await partidaLogroRepository.GetPartidaLogro(id);
        }

        public async Task<IEnumerable<PartidaLogro>> GetPartidasLogros()
        {
            return await partidaLogroRepository.GetPartidasLogros();
        }

        public async Task<PartidaLogro> CreatePartidaLogro(
           int IdPartida,
           int IdLogro,
           DateTime FechaLogro
          )
        {
            return await partidaLogroRepository.CreatePartidaLogro(new PartidaLogro
            {
                IdPartida = IdPartida,
                IdLogro = IdLogro,
                FechaLogro= FechaLogro
            });
        }

        public async Task<PartidaLogro> UpdatePartidaLogro(
           int IdPartidaLogro,
           int? IdPartida,
           int? IdLogro,
           DateTime? FechaLogro
           )
        {
            PartidaLogro? partidaLogro = await partidaLogroRepository.GetPartidaLogro(IdPartidaLogro);
            if (partidaLogro == null) throw new Exception("PartidaLogro not found");
            partidaLogro.IdPartida = IdPartida ?? partidaLogro.IdPartida;
            partidaLogro.IdLogro = IdLogro ?? partidaLogro.IdLogro;
            partidaLogro.FechaLogro = FechaLogro ?? partidaLogro.FechaLogro;
            return await partidaLogroRepository.UpdatePartidaLogro(partidaLogro);
        }

        public async Task<PartidaLogro> DeletePartidaLogro(int id)
        {
            return await partidaLogroRepository.DeletePartidaLogro(id);
        }
        
    }
    
}

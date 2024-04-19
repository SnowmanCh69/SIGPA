using SIGPA.Models;
using SIGPA.Repositories;


namespace SIGPA.Services
{
    public interface ILogroService
    {
        Task<IEnumerable<Logro>> GetLogros();
        Task<Logro?> GetLogro(int id);
        Task<Logro> CreateLogro(
           string NombreLogro,
           string DescripcionLogro,
           int IdTipoLogro
         );
        Task<Logro> UpdateLogro(
          int IdLogro,
          string? NombreLogro,
          string? DescripcionLogro,
          int? IdTipoLogro
        );
        
    }
    public class LogroService(ILogroRepository logroRepository): ILogroService
    {
        
        public async Task<Logro?> GetLogro(int id)
        {
            return await logroRepository.GetLogro(id);
        }

        public async Task<IEnumerable<Logro>> GetLogros()
        {
            return await logroRepository.GetLogros();
        }

        public async Task<Logro> CreateLogro(
            string NombreLogro,
            string DescripcionLogro,
            int IdTipoLogro
         )
        {
            return await logroRepository.CreateLogro(new Logro
            {
                NombreLogro = NombreLogro,
                DescripcionLogro = DescripcionLogro,
                IdTipoLogro = IdTipoLogro
            });
        }

        public async Task<Logro> UpdateLogro(
            int IdLogro,
            string? NombreLogro,
            string? DescripcionLogro,
            int? IdTipoLogro
          )
        {
            Logro? logro = await logroRepository.GetLogro(IdLogro);
            if (logro == null) throw new Exception("Logro not found");
            logro.NombreLogro = NombreLogro ?? logro.NombreLogro;
            logro.DescripcionLogro = DescripcionLogro ?? logro.DescripcionLogro;
            logro.IdTipoLogro = IdTipoLogro ?? logro.IdTipoLogro;
            return await logroRepository.UpdateLogro(logro);
        }

        public async Task<Logro> DeleteLogro(int id)
        {
            return await logroRepository.DeleteLogro(id);
        }
    }
}

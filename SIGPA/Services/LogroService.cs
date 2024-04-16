using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    public interface ILogroService
    {
        Task<List<Logro>> GetAll();
        Task<Logro?> GetLogro(int IdLogro);
        Task<Logro> CreateLogro(string nombreLogro, string descripcionLogro, int IdTipoLogro);
        Task<Logro> UpdateLogro(
            int IdLogro,
            string? nombreLogro = null,
            string? descripcionLogro = null,
            int? IdTipoLogro = null
       );
        Task<Logro> DeleteLogro(int idLogro);
    }

    public class LogroService : ILogroService
    {

        private readonly ILogroRepository _logroRepository;
        public LogroService(ILogroRepository logroRepository)
        {
            _logroRepository = logroRepository;
        }

        public async Task<List<Logro>> GetAll()
        {
            return await _logroRepository.GetAll();
        }

        public async Task<Logro?> GetLogro(int IdLogro)
        {
            return await _logroRepository.GetLogro(IdLogro);
        }

        public async Task<Logro> CreateLogro(string nombreLogro, string descripcionLogro, int IdTipoLogro)
        {
            return await _logroRepository.CreateLogro(nombreLogro, descripcionLogro, IdTipoLogro);
        }

        public async Task<Logro> UpdateLogro(
          int IdLogro,
          string? nombreLogro = null,
          string? descripcionLogro = null,
          int? IdTipoLogro = null
         )
        {
            var logro = await _logroRepository.GetLogro(IdLogro);
            if (logro == null)
            {
                // Manejar la situación en la que el logro no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Logro no encontrado");
            }

            if (nombreLogro != null)
            {
                logro.NombreLogro = nombreLogro;
            }

            if (descripcionLogro != null)
            {
                logro.DescripcionLogro = descripcionLogro;
            }

            if (IdTipoLogro != null)
            {
                logro.IdTipoLogro = (int)IdTipoLogro;
            }

            return await _logroRepository.UpdateLogro(logro);
        }

        public async Task<Logro> DeleteLogro(int idLogro)
        {
            return await _logroRepository.DeleteLogro(idLogro);
        }
    }
    
}

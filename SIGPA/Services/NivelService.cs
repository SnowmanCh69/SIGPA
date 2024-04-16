using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface INivelService
    {
        Task<List<Nivel>> GetAll();
        Task<Nivel?> GetNivel(int IdNivel);
        Task<Nivel> CreateNivel(string nombreNivel);
        Task<Nivel> UpdateNivel(
         int IdNivel,
         string? nombreNivel = null
                                                                    
     );
        Task<Nivel> DeleteNivel(int idNivel);
    }
    public class NivelService : INivelService
    {
        private readonly INivelRepository _nivelRepository;
        public NivelService(INivelRepository nivelRepository)
        {
            _nivelRepository = nivelRepository;
        }

        public async Task<List<Nivel>> GetAll()
        {
            return await _nivelRepository.GetAll();
        }

        public async Task<Nivel?> GetNivel(int IdNivel)
        {
            return await _nivelRepository.GetNivel(IdNivel);
        }

        public async Task<Nivel> CreateNivel(string nombreNivel)
        {
            return await _nivelRepository.CreateNivel(nombreNivel);
        }

        public async Task<Nivel> UpdateNivel(
           int IdNivel,
           string? nombreNivel = null
          )
        {
            var nivel = await _nivelRepository.GetNivel(IdNivel);
            if (nivel == null)
            {
                // Manejar la situación en la que el nivel no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Nivel no encontrado");
            }

            if (nombreNivel != null)
            {
                nivel.NombreNivel = nombreNivel;
            }

            return await _nivelRepository.UpdateNivel(nivel);
        }

        public async Task<Nivel> DeleteNivel(int idNivel)
        {
            return await _nivelRepository.DeleteNivel(idNivel);
        }
    }
}

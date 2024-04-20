using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface INivelService
    {
        Task<IEnumerable<Nivel>> GetNiveles();
        Task<Nivel?> GetNivel(int id);
        Task<Nivel> CreateNivel(
          string NombreNivel
         );
        Task<Nivel> UpdateNivel(
          int IdNivel,
          string? NombreNivel
        );
        Task<Nivel?> DeleteNivel(int id);
    }
    public class NivelService(INivelRepository nivelRepository) : INivelService
    {
    
        public async Task<Nivel?> GetNivel(int id)
        {
            return await nivelRepository.GetNivel(id);
        }

        public async Task<IEnumerable<Nivel>> GetNiveles()
        {
            return await nivelRepository.GetNiveles();
        }

        public async Task<Nivel> CreateNivel(
          string NombreNivel
         )
        {
            return await nivelRepository.CreateNivel(new Nivel
            {
                NombreNivel = NombreNivel
            });
        }

        public async Task<Nivel> UpdateNivel(
           int IdNivel,
            string? NombreNivel
        )
        {
            Nivel? nivel = await nivelRepository.GetNivel(IdNivel);
            if (nivel == null) throw new Exception("Nivel not found");
            nivel.NombreNivel = NombreNivel ?? nivel.NombreNivel;
            return await nivelRepository.UpdateNivel(nivel);
        }

        public async Task<Nivel?> DeleteNivel(int id)
        {
            return await nivelRepository.DeleteNivel(id);
        } 
    }
}

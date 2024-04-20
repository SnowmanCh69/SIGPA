using SIGPA.Models;
using SIGPA.Repositories;


namespace SIGPA.Services
{
    public interface IResultadoService
    {
        Task<IEnumerable<Resultado>> GetResultados();
        Task<Resultado?> GetResultado(int id);
        Task<Resultado> CreateResultado(
           string NombreResultado
        );
        Task<Resultado> UpdateResultado(
            int IdResultado,
            string? NombreResultado
        );
        Task<Resultado?> DeleteResultado(int id);
    }
    public class ResultadoService(IResultadoRepository resultadoRepository) : IResultadoService
    {
        
        public async Task<Resultado?> GetResultado(int id)
        {
            return await resultadoRepository.GetResultado(id);
        }

        public async Task<IEnumerable<Resultado>> GetResultados()
        {
            return await resultadoRepository.GetResultados();
        }

        public async Task<Resultado> CreateResultado(
                      string NombreResultado
                     )
        {
            return await resultadoRepository.CreateResultado(new Resultado
            {
                NombreResultado = NombreResultado
            });
        }

        public async Task<Resultado> UpdateResultado(
             int IdResultado,
             string? NombreResultado
         )
        {
            Resultado? resultado = await resultadoRepository.GetResultado(IdResultado);
            if (resultado == null) throw new Exception("Resultado not found");
            resultado.NombreResultado = NombreResultado ?? resultado.NombreResultado;
            return await resultadoRepository.UpdateResultado(resultado);
        }

        public async Task<Resultado?> DeleteResultado(int id)
        {
            return await resultadoRepository.DeleteResultado(id);
        } 
    }
}

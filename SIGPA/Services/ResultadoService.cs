using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IResultadoService
    {
        Task<List<Resultado>> GetAll();
        Task<Resultado> GetResultado(int IdResultado);
        Task<Resultado> CreateResultado(string NombreResultado);
        Task<Resultado> UpdateResultado(
         int IdResultado,
         string? NombreResultado = null
      );
        Task<Resultado> DeleteResultado(int IdResultado);
    }
    public class ResultadoService : IResultadoService
    {
        private readonly IResultadoRepository _resultadoRepository;
        public ResultadoService(IResultadoRepository resultadoRepository)
        {
            _resultadoRepository = resultadoRepository;
        }

        public async Task<List<Resultado>> GetAll()
        {
            return await _resultadoRepository.GetAll();
        }

        public async Task<Resultado> GetResultado(int IdResultado)
        {
            return await _resultadoRepository.GetResultado(IdResultado);
        }

        public async Task<Resultado> CreateResultado(string NombreResultado)
        {
            return await _resultadoRepository.CreateResultado(NombreResultado);
        }

        public async Task<Resultado> UpdateResultado(
           int IdResultado,
            string? NombreResultado = null
                   )
        {
            var resultado = await _resultadoRepository.GetResultado(IdResultado);
            if (resultado == null)
            {
                throw new Exception("Resultado not found");
            }

            if (NombreResultado != null)
            {
                resultado.NombreResultado = NombreResultado;
            }

            return await _resultadoRepository.UpdateResultado(resultado);
        }

        public async Task<Resultado> DeleteResultado(int IdResultado)
        {
            return await _resultadoRepository.DeleteResultado(IdResultado);
        }
    }
}

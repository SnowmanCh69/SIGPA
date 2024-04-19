using SIGPA.Models;
using SIGPA.Repositories;


namespace SIGPA.Services
{
    public interface IEstadoResiduosService
    {
        Task<IEnumerable<EstadoResiduos>> GetEstadosResiduos();
        Task<EstadoResiduos?> GetEstadoResiduo(int id);
        Task<EstadoResiduos> CreateEstadoResiduo(
            string NombreEstadoResiduos
        );
        Task<EstadoResiduos> UpdateEstadoResiduo(
           int IdEstadoResiduos,
           string? NombreEstadoResiduos
         );
        Task<EstadoResiduos> DeleteEstadoResiduo(int id);
    }
    public class EstadoResiduosService(IEstadoResiduosRepository estadoResiduosRepository): IEstadoResiduosService
    {
        
        public async Task<EstadoResiduos?> GetEstadoResiduo(int id)
        {
            return await estadoResiduosRepository.GetEstadoResiduo(id);
        }

        public async Task<IEnumerable<EstadoResiduos>> GetEstadosResiduos()
        {
            return await estadoResiduosRepository.GetEstadosResiduos();
        }

        public async Task<EstadoResiduos> CreateEstadoResiduo(
           string NombreEstadoResiduos
         )
        {
            return await estadoResiduosRepository.CreateEstadoResiduo(new EstadoResiduos
            {
                NombreEstadoResiduos = NombreEstadoResiduos
            });
        }

        public async Task<EstadoResiduos> UpdateEstadoResiduo(
           int IdEstadoResiduos,
           string? NombreEstadoResiduos
         )
        {
            EstadoResiduos? estadoResiduos = await estadoResiduosRepository.GetEstadoResiduo(IdEstadoResiduos);
            if (estadoResiduos == null) throw new Exception("EstadoResiduos not found");
            estadoResiduos.NombreEstadoResiduos = NombreEstadoResiduos ?? estadoResiduos.NombreEstadoResiduos;
            return await estadoResiduosRepository.UpdateEstadoResiduo(estadoResiduos);
        }

        public async Task<EstadoResiduos> DeleteEstadoResiduo(int id)
        {
            return await estadoResiduosRepository.DeleteEstadoResiduo(id);
        }
    }
}

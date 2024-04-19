using SIGPA.Models;
using SIGPA.Repositories;


namespace SIGPA.Services
{
    public interface IEstadoRutaService
    {
        Task<IEnumerable<EstadoRuta>> GetEstadosRuta();
        Task<EstadoRuta?> GetEstadoRuta(int id);
        Task<EstadoRuta> CreateEstadoRuta(
         string NombreEstadoRuta
        );
        Task<EstadoRuta> UpdateEstadoRuta(
          int IdEstadoRuta,
          string? NombreEstadoRuta
        );
        Task<EstadoRuta> DeleteEstadoRuta(int id);
    }
    public class EstadoRutaService(IEstadoRutaRepository estadoRutaRepository): IEstadoRutaService
    {
        
        public async Task<EstadoRuta?> GetEstadoRuta(int id)
        {
            return await estadoRutaRepository.GetEstadoRuta(id);
        }

        public async Task<IEnumerable<EstadoRuta>> GetEstadosRuta()
        {
            return await estadoRutaRepository.GetEstadosRuta();
        }

        public async Task<EstadoRuta> CreateEstadoRuta(
           string NombreEstadoRuta
         )
        {
            return await estadoRutaRepository.CreateEstadoRuta(new EstadoRuta
            {
                NombreEstadoRuta = NombreEstadoRuta
            });
        }

        public async Task<EstadoRuta> UpdateEstadoRuta(
          int IdEstadoRuta,
          string? NombreEstadoRuta
          )
        {
            EstadoRuta? estadoRuta = await estadoRutaRepository.GetEstadoRuta(IdEstadoRuta);
            if (estadoRuta == null) throw new Exception("EstadoRuta not found");
            estadoRuta.NombreEstadoRuta = NombreEstadoRuta ?? estadoRuta.NombreEstadoRuta;
            return await estadoRutaRepository.UpdateEstadoRuta(estadoRuta);
        }

        public async Task<EstadoRuta> DeleteEstadoRuta(int id)
        {
            return await estadoRutaRepository.DeleteEstadoRuta(id);
        }
        
    }
    
}

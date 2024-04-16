using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    interface IResiduosService
    {
        Task<List<Residuos>> GetAll();
        Task<Residuos> GetResiduos(int IdResiduos);
        Task<Residuos> CreateResiduos(int IdEstadoResiduos, string CantidadRegistrada, int IdTipoResiduos, int IdUsuario, int IdResiduosPartida);
        Task<Residuos> UpdateResiduos(
          int IdResiduos,
          int? IdEstadoResiduos = null,
          string? CantidadRegistrada = null,
          int? IdTipoResiduos = null,
          int? IdUsuario = null,
           int? IdResiduosPartida = null
        );
        Task<Residuos> DeleteResiduos(int idResiduos);
    }
    public class ResiduosService: IResiduosService
    {
        private readonly IResiduosRepository _residuosRepository;
        public ResiduosService(IResiduosRepository residuosRepository)
        {
            _residuosRepository = residuosRepository;
        }

        public async Task<List<Residuos>> GetAll()
        {
            return await _residuosRepository.GetAll();
        }

        public async Task<Residuos> GetResiduos(int IdResiduos)
        {
            return await _residuosRepository.GetResiduos(IdResiduos);
        }

        public async Task<Residuos> CreateResiduos(int IdEstadoResiduos, string CantidadRegistrada, int IdTipoResiduos, int IdUsuario, int IdResiduosPartida)
        {
            return await _residuosRepository.CreateResiduos(IdEstadoResiduos, CantidadRegistrada, IdTipoResiduos, IdUsuario, IdResiduosPartida);
        }

        public async Task<Residuos> UpdateResiduos(
            int IdResiduos,
            int? IdEstadoResiduos = null,
            string? CantidadRegistrada = null,
            int? IdTipoResiduos = null,
             int? IdUsuario = null,
             int? IdResiduosPartida = null
        )
        {
            var residuos = await _residuosRepository.GetResiduos(IdResiduos);
            if (residuos == null)
            {
                throw new Exception("Residuos not found");
            }

            if(IdEstadoResiduos!= null)
            {
                residuos.IdEstadoResiduos = (int)IdEstadoResiduos;

            }

            if(CantidadRegistrada!= null)
            {
                residuos.CantidadRegistrada = (string)CantidadRegistrada;

            }

            if(IdTipoResiduos!= null)
            {
                residuos.IdTipoResiduos = (int)IdTipoResiduos;

            }

            if(IdUsuario!= null)
            {
                residuos.IdUsuario = (int)IdUsuario;

            }

            if(IdResiduosPartida!= null)
            {
                residuos.IdResiduosPartida = (int)IdResiduosPartida;

            }

            return await _residuosRepository.UpdateResiduos(residuos);
        }

        
        public async Task<Residuos> DeleteResiduos(int idResiduos)
        {
            return await _residuosRepository.DeleteResiduos(idResiduos);
        }
    }
    
}

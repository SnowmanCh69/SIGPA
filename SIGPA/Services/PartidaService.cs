using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{

    public interface IPartidaService
    {
        Task<List<Partida>> GetAll();
        Task<Partida?> GetPartida(int IdPartida);
        Task<Partida> CreatePartida(int IdUsuario, DateTime FechaInicioPartida, DateTime FechaFinPartida, int IdNivel, string UbicacionJugador, int CantidadVidas, int IdResiduos);
        Task<Partida> UpdatePartida(
         int IdPartida,
         int? IdUsuario = null,
         DateTime? FechaInicioPartida = null,
         DateTime? FechaFinPartida = null,
         int? IdNivel = null,
         string? UbicacionJugador = null,
         int? CantidadVidas = null,
         int? IdResiduos = null
                   );
        Task<Partida> DeletePartida(int idPartida);
    }

    public class PartidaService: IPartidaService
    {

        private readonly IPartidaRepository _partidaRepository;
        public PartidaService(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<List<Partida>> GetAll()
        {
            return await _partidaRepository.GetAll();
        }

        public async Task<Partida?> GetPartida(int IdPartida)
        {
            return await _partidaRepository.GetPartida(IdPartida);
        }

        public async Task<Partida> CreatePartida(int IdUsuario, DateTime FechaInicioPartida, DateTime FechaFinPartida, int IdNivel, string UbicacionJugador, int CantidadVidas, int IdResiduos)
        {
            return await _partidaRepository.CreatePartida(IdUsuario, FechaInicioPartida, FechaFinPartida, IdNivel, UbicacionJugador, CantidadVidas, IdResiduos);
        }

        
        public async Task<Partida> UpdatePartida(
           int IdPartida,
           int? IdUsuario = null,
           DateTime? FechaInicioPartida = null,
           DateTime? FechaFinPartida = null,
           int? IdNivel = null,
           string? UbicacionJugador = null,
           int? CantidadVidas = null,
            int? IdResiduos = null
         )
        {
            var partida = await _partidaRepository.GetPartida(IdPartida);
            if (partida == null)
            {
                // Manejar la situación en la que la partida no existe
                // Por ejemplo, lanzar una excepción o devolver un resultado indicando el error
                throw new Exception("Partida no encontrada");
            }

            if (IdUsuario != null)
            {
                partida.IdUsuario = (int)IdUsuario;
            }
            if (FechaInicioPartida != null)
            {
                partida.FechaInicioPartida = (DateTime)FechaInicioPartida;
            }
            if (FechaFinPartida != null)
            {
                partida.FechaFinPartida = (DateTime)FechaFinPartida;
            }
            if (IdNivel != null)
            {
                partida.IdNivel = (int)IdNivel;
            }
            if (UbicacionJugador != null)
            {
                partida.UbicacionJugador = UbicacionJugador;
            }
            if (CantidadVidas != null)
            {
                partida.CantidadVidas = (int)CantidadVidas;
            }
            if (IdResiduos != null)
            {
                partida.IdResiduos = (int)IdResiduos;
            }

            return await _partidaRepository.UpdatePartida(partida);
        }


        public async Task<Partida> DeletePartida(int idPartida)
        {
            return await _partidaRepository.DeletePartida(idPartida);
        }
    }
}

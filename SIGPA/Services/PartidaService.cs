using SIGPA.Models;
using SIGPA.Repositories;


namespace SIGPA.Services
{
    public interface IPartidaService
    {
        Task<IEnumerable<Partida>> GetPartidas();
        Task<Partida?> GetPartida(int id);
        Task<Partida> CreatePartida(
          int IdUsuario,
          DateTime FechaInicioPartida,
          DateTime FechaFinPartida,
          int IdNivel,
          string UbicacionJugador,
          string Puntuacion
        );
        Task<Partida> UpdatePartida(
           int IdPartida,
           int? IdUsuario,
           DateTime? FechaInicioPartida,
           DateTime? FechafINPartida,
           int? IdNivel,
           string? UbicacionJugador,
           string? Puntuacion
       );
        Task<Partida?> DeletePartida(int id);
    }
    public class PartidaService(IPartidaRepository partidaRepository) : IPartidaService
    {

        public async Task<Partida?> GetPartida(int id)
        {
            return await partidaRepository.GetPartida(id);
        }

        public async Task<IEnumerable<Partida>> GetPartidas()
        {
            return await partidaRepository.GetPartidas();
        }

        public async Task<Partida> CreatePartida(
            int IdUsuario,
            DateTime FechaInicioPartida,
            DateTime FechaFinPartida,
            int IdNivel,
            string UbicacionJugador,
            string Puntuacion
        )
        {
            return await partidaRepository.CreatePartida(new Partida
            {
                IdUsuario = IdUsuario,
                FechaInicioPartida = FechaInicioPartida,
                FechaFinPartida = FechaFinPartida,
                IdNivel = IdNivel,
                UbicacionJugador = UbicacionJugador,
                Puntuacion = Puntuacion
            });
        }

        public async Task<Partida> UpdatePartida(
               int IdPartida,
                int? IdUsuario,
                DateTime? FechaInicioPartida,
                DateTime? FechaFinPartida,
                int? IdNivel,
                string? UbicacionJugador,
                string? Puntuacion
         )
        {
            Partida? partida = await partidaRepository.GetPartida(IdPartida);
            if (partida == null) throw new Exception("Partida not found");
            partida.IdUsuario = IdUsuario ?? partida.IdUsuario;
            partida.FechaInicioPartida = FechaInicioPartida ?? partida.FechaInicioPartida;
            partida.FechaFinPartida = FechaFinPartida ?? partida.FechaFinPartida;
            partida.IdNivel = IdNivel ?? partida.IdNivel;
            partida.UbicacionJugador = UbicacionJugador ?? partida.UbicacionJugador;
            partida.Puntuacion = Puntuacion ?? partida.Puntuacion;
            return await partidaRepository.UpdatePartida(partida);
        }

        public async Task<Partida?> DeletePartida(int id)
        {
            return await partidaRepository.DeletePartida(id);
        }
    }
}

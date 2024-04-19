using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PartidaController(IPartidaService partidaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPartidas()
        {
            IEnumerable<Partida> partidas = await partidaService.GetPartidas();
            return Ok(partidas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPartida(int id)
        {
            Partida? partida = await partidaService.GetPartida(id);
            if (partida == null)
            {
                return NotFound();
            }
            return Ok(partida);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartida(
           int IdUsuario,
           DateTime FechaInicioPartida,
           DateTime FechaFinPartida,
           int IdNivel,
           string UbicacionJugador,
           int CantidadVidas,
           int IdResiduo
         )
        {
            var partida = await partidaService.CreatePartida(IdUsuario, FechaInicioPartida, FechaFinPartida, IdNivel, UbicacionJugador, CantidadVidas, IdResiduo);
            return CreatedAtAction(nameof(GetPartida), new { id = partida.IdPartida }, partida);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartida(
           int IdPartida,
           int? IdUsuario,
           DateTime? FechaInicioPartida,
           DateTime? FechaFinPartida,
           int? IdNivel,
           string? UbicacionJugador,
           int? CantidadVidas,
           int? IdResiduo
        )
        {
            var partida = await partidaService.UpdatePartida(IdPartida, IdUsuario, FechaInicioPartida, FechaFinPartida, IdNivel, UbicacionJugador, CantidadVidas, IdResiduo);
            return Ok(partida);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            var deletedPartida = await partidaService.DeletePartida(id);
            if (deletedPartida == null) return NotFound();
            return Ok(deletedPartida);
        }
    }
}

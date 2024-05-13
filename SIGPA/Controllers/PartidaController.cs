using Microsoft.AspNetCore.Mvc;
using SIGPA.Helpers;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

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
           [FromForm][Required] int IdUsuario,
           [FromForm][Required] DateTime FechaInicioPartida,
           [FromForm] DateTime FechaFinPartida,
           [FromForm][Required] int IdNivel,
           [FromForm][Required] string UbicacionJugador,
           [FromForm][Required] string Puntuacion
         )
        {
            var partida = await partidaService.CreatePartida(IdUsuario, FechaInicioPartida, FechaFinPartida, IdNivel, UbicacionJugador, Puntuacion);
            return CreatedAtAction(nameof(GetPartida), new { id = partida.IdPartida }, partida);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartida(
           [FromForm][Required] int IdPartida,
           [FromForm] int? IdUsuario,
           [FromForm] DateTime? FechaInicioPartida,
           [FromForm] DateTime? FechaFinPartida,
           [FromForm] int? IdNivel,
           [FromForm] string? UbicacionJugador,
           [FromForm] string? Puntuacion
        )
        {
            var partida = await partidaService.UpdatePartida(IdPartida, IdUsuario, FechaInicioPartida, FechaFinPartida, IdNivel, UbicacionJugador, Puntuacion);
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

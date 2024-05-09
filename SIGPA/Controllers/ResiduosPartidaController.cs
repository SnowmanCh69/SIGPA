using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResiduosPartidaController(IResiduosPartidaService residuosPartidaService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetResiduosPartida()
        {
            IEnumerable<ResiduosPartida> residuosPartida = await residuosPartidaService.GetResiduosPartida();
            return Ok(residuosPartida);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetResiduoPartida(int id)
        {
            ResiduosPartida? residuoPartida = await residuosPartidaService.GetResiduoPartida(id);
            if (residuoPartida == null)
            {
                return NotFound();
            }
            return Ok(residuoPartida);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResiduoPartida(
           [FromForm][Required] int IdPartida,
           [FromForm][Required] int IdResiduo,
           [FromForm][Required] string CantidadRegistrada

         )
        {
            var residuoPartida = await residuosPartidaService.CreateResiduoPartida(IdPartida, IdResiduo, CantidadRegistrada);
            return CreatedAtAction(nameof(GetResiduoPartida), new { id = residuoPartida.IdResiduosPartida }, residuoPartida);
           
        }

        [HttpPut]

        public async Task<IActionResult> UpdateResiduoPartida(
           [FromForm] int IdResiduosPartida,
           [FromForm] int? IdPartida,
           [FromForm] int? IdResiduo,
           [FromForm] string? CantidadRegistrada
         )
        {
            var residuoPartida = await residuosPartidaService.UpdateResiduoPartida(IdResiduosPartida, IdPartida, IdResiduo, CantidadRegistrada);
            return Ok(residuoPartida);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteResiduoPartida(int id)
        {
            var deletedResiduoPartida = await residuosPartidaService.DeleteResiduoPartida(id);
            if (deletedResiduoPartida == null) return NotFound();
            return Ok(deletedResiduoPartida);
        }
    }
}

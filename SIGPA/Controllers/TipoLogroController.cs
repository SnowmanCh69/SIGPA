using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLogroController(ITipoLogroService tipoLogroService): ControllerBase
    {

      [HttpGet]
      public async Task<IActionResult> GetTipoLogros()
       {
        IEnumerable<TipoLogro> tipoLogros = await tipoLogroService.GetTipoLogros();
        return Ok(tipoLogros);
       }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTipoLogro(int id)
        {
            TipoLogro? tipoLogro = await tipoLogroService.GetTipoLogro(id);
            if (tipoLogro == null) return NotFound();
            return Ok(tipoLogro);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoLogro
        (
           string NombreTipoLogro
        )
        {
            var tipoLogro = await tipoLogroService.CreateTipoLogro(NombreTipoLogro);
            return CreatedAtAction(nameof(GetTipoLogro), new { id = tipoLogro.IdTipoLogro }, tipoLogro);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTipoLogro
        (
            int IdTipoLogro,
            string? NombreTipoLogro
        )
        {
            var tipoLogro = await tipoLogroService.UpdateTipoLogro(IdTipoLogro, NombreTipoLogro);
            return Ok(tipoLogro);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTipoLogro(int id)
        {
            var deletedTipoLogro = await tipoLogroService.DeleteTipoLogro(id);
            if(deletedTipoLogro == null) return NotFound();
            return Ok(deletedTipoLogro);
        }

    }
}

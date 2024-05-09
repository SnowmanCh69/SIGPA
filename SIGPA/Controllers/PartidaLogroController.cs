using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaLogroController (IPartidaLogroService partidaLogroService) :ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPartidasLogro()
        {
            IEnumerable<PartidaLogro> partidasLogro = await partidaLogroService.GetPartidasLogros();
            return Ok(partidasLogro);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPartidaLogro(int id)
        {
            PartidaLogro? partidaLogro = await partidaLogroService.GetPartidaLogro(id);
            if (partidaLogro == null)
            {
                return NotFound();
            }
            return Ok(partidaLogro);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartidaLogro(
           [FromForm][Required] int IdPartida,
           [FromForm][Required] int IdLogro,
           [FromForm][Required] DateTime FechaLogro
        )
        {
            var partidaLogro = await partidaLogroService.CreatePartidaLogro(IdPartida, IdLogro, FechaLogro);
            return CreatedAtAction(nameof(GetPartidaLogro), new { id = partidaLogro.IdPartidaLogro }, partidaLogro);
        }

        [HttpPut]
        
        public async Task<IActionResult> UpdatePartidaLogro(
         [FromForm][Required] int IdPartidaLogro,
         [FromForm] int? IdPartida,
         [FromForm] int? IdLogro,
         [FromForm] DateTime? FechaLogro
         )
        {
            var partidaLogro = await partidaLogroService.UpdatePartidaLogro(IdPartidaLogro, IdPartida, IdLogro, FechaLogro);
            return Ok(partidaLogro);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePartidaLogro(int id)
        {
            var deletedPartidaLogro = await partidaLogroService.DeletePartidaLogro(id);
            if (deletedPartidaLogro == null) return NotFound();
            return Ok(deletedPartidaLogro);
        }
    }
}

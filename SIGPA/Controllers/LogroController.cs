using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;


namespace SIGPA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogroController(ILogroService logroService): ControllerBase
    {

        [HttpGet]
        
        public async Task<IActionResult> GetLogros()
        {
            IEnumerable<Logro> logros = await logroService.GetLogros();
            return Ok(logros);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetLogro(int id)
        {
            Logro? logro = await logroService.GetLogro(id);
            if (logro == null) return NotFound();
            return Ok(logro);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLogro
        (
            [FromForm][Required] string NombreLogro,
            [FromForm][Required] string DescripcionLogro,
            [FromForm][Required] int IdTipoLogro
         )
         {
            var logro = await logroService.CreateLogro(NombreLogro, DescripcionLogro, IdTipoLogro);
            return CreatedAtAction(nameof(GetLogro), new { id = logro.IdLogro }, logro);
         }

        [HttpPut]
        public async Task<IActionResult> UpdateLogro
        (
           [FromForm][Required] int IdLogro,
           [FromForm] string? NombreLogro,
           [FromForm] string? DescripcionLogro,
           [FromForm] int? IdTipoLogro
        )
        {
            var logro = await logroService.UpdateLogro(IdLogro, NombreLogro, DescripcionLogro, IdTipoLogro);
            return Ok(logro);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLogro(int id)
        {
            var deletedLogro = await logroService.DeleteLogro(id);
            if(deletedLogro == null) return NotFound();
            return Ok(deletedLogro);
        }
    }   
   
}

using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;



namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NivelController(INivelService nivelService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetNiveles()
        {
            IEnumerable<Nivel> niveles = await nivelService.GetNiveles();
            return Ok(niveles);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNivel(int id)
        {
            Nivel? nivel = await nivelService.GetNivel(id);
            if (nivel == null)
            {
                return NotFound();
            }
            return Ok(nivel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNivel(
           string NombreNivel
         )
        {
            var nivel= await nivelService.CreateNivel(NombreNivel);
            return CreatedAtAction(nameof(GetNivel), new { id = nivel.IdNivel }, nivel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNivel(
            int IdNivel,
            string? NombreNivel
         )
        {
            var nivel = await nivelService.UpdateNivel(IdNivel, NombreNivel);
            return Ok(nivel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNivel(int id)
        {
            var deletedNivel = await nivelService.DeleteNivel(id);
            if (deletedNivel == null) return NotFound();
            return Ok(deletedNivel);
        }
    }
}

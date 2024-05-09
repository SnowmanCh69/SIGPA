using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecolectaResiduosController(IRecolectaResiduosService recolectaResiduosService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRecolectaResiduos()
        {
            IEnumerable<RecolectaResiduos> recolectaResiduos = await recolectaResiduosService.GetRecolectasResiduos();
            return Ok(recolectaResiduos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecolectaResiduo(int id)
        {
            RecolectaResiduos? recolectaResiduos = await recolectaResiduosService.GetRecolectaResiduos(id);
            if (recolectaResiduos == null)
            {
                return NotFound();
            }
            return Ok(recolectaResiduos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecolectaResiduo(
           [FromForm][Required] int IdRutaRecolecta,
           [FromForm][Required] int IdResiduo,
           [FromForm][Required] int IdUsuario,
           [FromForm][Required] string CantidadRecolectada,
           [FromForm][Required] DateOnly FechaRecoleccion
         )
        {
            var recolectaResiduo = await recolectaResiduosService.CreateRecolectaResiduos(IdRutaRecolecta, IdResiduo, IdUsuario, CantidadRecolectada, FechaRecoleccion);
            return CreatedAtAction(nameof(GetRecolectaResiduo), new { id = recolectaResiduo.IdRecolectaResiduos }, recolectaResiduo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecolectaResiduos(
            [FromForm][Required] int IdRecolectaResiduos,
            [FromForm] int? IdRutaRecolecta,
            [FromForm] int? IdResiduo,
            [FromForm] int? IdUsuario,
            [FromForm] string? CantidadRecolectada,
            [FromForm] DateOnly? FechaRecoleccion
          )
        {
            var recolectaResiduo = await recolectaResiduosService.UpdateRecolectaResiduos(IdRecolectaResiduos, IdRutaRecolecta, IdResiduo, IdUsuario, CantidadRecolectada, FechaRecoleccion);
            return CreatedAtAction(nameof(GetRecolectaResiduo), new { id = recolectaResiduo.IdRecolectaResiduos }, recolectaResiduo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecolectaResiduo(int id)
        {
            var deletedRecolectaResiduo = await recolectaResiduosService.DeleteRecolectaResiduos(id);
            if (deletedRecolectaResiduo == null) return NotFound();
            return Ok(deletedRecolectaResiduo);
        }
    }
}

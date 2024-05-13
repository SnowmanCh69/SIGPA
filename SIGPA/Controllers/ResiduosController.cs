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
    public class ResiduosController(IResiduosService residuosService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetResiduos()
        {
            IEnumerable<Residuos> residuos = await residuosService.GetResiduos();
            return Ok(residuos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetResiduo(int id)
        {
            Residuos? residuo = await residuosService.GetResiduo(id);
            if (residuo == null)
            {
                return NotFound();
            }
            return Ok(residuo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResiduo(
           [FromForm][Required] string NombreResiduo,
           [FromForm][Required] DateOnly FechaRegistro,
           [FromForm][Required] int IdEstadoResiduos,
           [FromForm][Required] string CantidadRegistrada,
           [FromForm][Required] int IdUsuario
        )
        {
            var residuo = await residuosService.CreateResiduo(NombreResiduo, FechaRegistro, IdEstadoResiduos, CantidadRegistrada, IdUsuario);
            return CreatedAtAction(nameof(GetResiduo), new { id = residuo.IdResiduos }, residuo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResiduo(
           [FromForm][Required] int IdResiduo,
           [FromForm] string? NombreResiduo,
           [FromForm] DateOnly? FechaRegistro,
           [FromForm] int? IdEstadoResiduos,
           [FromForm] string? CantidadRegistrada,
           [FromForm] int? IdUsuario
           )
        {
            
            var residuo = await residuosService.UpdateResiduo(IdResiduo, NombreResiduo, FechaRegistro, IdEstadoResiduos, CantidadRegistrada, IdUsuario);
            return Ok(residuo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteResiduo(int id)
        {
            var deletedResiduo = await residuosService.DeleteResiduo(id);
            if (deletedResiduo == null) return NotFound();
            return Ok(deletedResiduo);
        }
    }
}

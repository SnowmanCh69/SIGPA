using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            string NombreResiduo,
           DateTime FechaRegistro,
           int IdEstadoResiduos,
           string CantidadRegistrada,
           int IdUsuario,
           int IdResiduosPartida
        )
        {
            var residuo = await residuosService.CreateResiduo(NombreResiduo, FechaRegistro, IdEstadoResiduos, CantidadRegistrada, IdUsuario, IdResiduosPartida);
            return CreatedAtAction(nameof(GetResiduo), new { id = residuo.IdResiduos }, residuo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResiduo(
          int IdResiduo,
           string? NombreResiduo,
           DateTime? FechaRegistro,
           int? IdEstadoResiduos,
           string? CantidadRegistrada,
           int? IdUsuario,
           int? IdResiduosPartida
           )
        {
            
            var residuo = await residuosService.UpdateResiduo(IdResiduo, NombreResiduo, FechaRegistro, IdEstadoResiduos, CantidadRegistrada, IdUsuario, IdResiduosPartida);
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

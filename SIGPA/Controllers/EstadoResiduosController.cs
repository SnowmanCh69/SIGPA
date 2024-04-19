
using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EstadoResiduosController (IEstadoResiduosService estadoResiduosService): ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetEstadosResiduos()
        {
            IEnumerable<EstadoResiduos> estadosResiduos = await estadoResiduosService.GetEstadosResiduos();
            return Ok(estadosResiduos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEstadoResiduo(int id)
        {
            EstadoResiduos? estadoResiduo = await estadoResiduosService.GetEstadoResiduo(id);
            if (estadoResiduo == null) return NotFound();
            return Ok(estadoResiduo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstadoResiduos(
            string NombreEstadoResiduos
        )
        {
            var estadoResiduo = await estadoResiduosService.CreateEstadoResiduo(NombreEstadoResiduos);
            return CreatedAtAction(nameof(GetEstadoResiduo), new { id = estadoResiduo.IdEstadoResiduos }, estadoResiduo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEstadoResiduo(
          int IdEstadoResiduos,
          string? NombreEstadoResiduos
        )
        {
            
           var estadoResiduo = await estadoResiduosService.UpdateEstadoResiduo(IdEstadoResiduos, NombreEstadoResiduos);
           return Ok(estadoResiduo);
            
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEstadoResiduo(int id)
        {
            var deletedEstadoResiduo = await estadoResiduosService.DeleteEstadoResiduo(id);
            if (deletedEstadoResiduo == null) return NotFound();
            return Ok(deletedEstadoResiduo);
        }
    }
}

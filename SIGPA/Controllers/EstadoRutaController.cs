using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoRutaController(IEstadoRutaService estadoRutaService): ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetEstadosRuta()
        {
            IEnumerable<EstadoRuta> estadosRuta = await estadoRutaService.GetEstadosRuta();
            return Ok(estadosRuta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoRuta(int id)
        {
            EstadoRuta? estadoRuta = await estadoRutaService.GetEstadoRuta(id);
            if (estadoRuta == null) return NotFound();
            return Ok(estadoRuta);
        }

        [HttpPost]
        
        public async Task<IActionResult> CreateEstadoRuta(
           [FromForm][Required] string NombreEstadoRuta
        )
        {
            var estadoRuta = await estadoRutaService.CreateEstadoRuta(NombreEstadoRuta);
            return CreatedAtAction(nameof(GetEstadoRuta), new { id = estadoRuta.IdEstadoRuta }, estadoRuta);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEstadoRuta(
          [FromForm][Required] int IdEstadoRuta,
          [FromForm] string? NombreEstadoRuta
          )
        {
            var estadoRuta = await estadoRutaService.UpdateEstadoRuta(IdEstadoRuta, NombreEstadoRuta);
            return Ok(estadoRuta);   
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEstadoRuta(int id)
        {
            var deletedEstadoRuta = await estadoRutaService.DeleteEstadoRuta(id);
            if (deletedEstadoRuta  == null) return NotFound();
            return Ok(deletedEstadoRuta );
        }
    }
}

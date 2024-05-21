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

    public class RutaRecoletaController(IRutaRecolectaService rutaRecolectaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRutasRecolecta()
        {
            IEnumerable<RutaRecolecta> rutasRecolecta = await rutaRecolectaService.GetRutasRecolecta();
            return Ok(rutasRecolecta);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRutaRecolecta(int id)
        {
            RutaRecolecta? rutaRecolecta = await rutaRecolectaService.GetRutaRecolecta(id);
            if (rutaRecolecta == null)
            {
                return NotFound();
            }
            return Ok(rutaRecolecta);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRutaRecolecta(
          [FromForm][Required] string PuntoIncio,
          [FromForm][Required] string PuntoFinalizacion,
          [FromForm][Required] int IdEstadoRuta,
          [FromForm][Required] int IdUsuario,
          [FromForm][Required] int IdVehiculo,
          [FromForm][Required] int IdResiduo,
          [FromForm][Required] DateOnly FechaRecoleccion
        )
        {
            var rutaRecolecta = await rutaRecolectaService.CreateRutaRecolecta(PuntoIncio, PuntoFinalizacion, IdEstadoRuta, IdUsuario, IdVehiculo, IdResiduo, FechaRecoleccion);
            return CreatedAtAction(nameof(GetRutaRecolecta), new { id = rutaRecolecta.IdRutaRecolecta }, rutaRecolecta);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRutaRecolecta(
          [FromForm][Required] int IdRutaRecolecta,
          [FromForm] string? PuntoIncio,
          [FromForm] string? PuntoFinalizacion,
          [FromForm] int? IdEstadoRuta,
          [FromForm] int? IdUsuario,
          [FromForm] int? IdVehiculo,
          [FromForm] int? IdResiduo,
          [FromForm] DateOnly? FechaRecoleccion
          
         )
        {
            var rutaRecolecta = await rutaRecolectaService.UpdateRutaRecolecta(IdRutaRecolecta, PuntoIncio, PuntoFinalizacion, IdEstadoRuta, IdUsuario, IdVehiculo, IdResiduo,FechaRecoleccion);
            return Ok(rutaRecolecta);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRutaRecolecta(int id)
        {
            var deletedRutaRecolecta = await rutaRecolectaService.DeleteRutaRecolecta(id);
            if (deletedRutaRecolecta == null) return NotFound();
            return Ok(deletedRutaRecolecta);
        }
    }
}

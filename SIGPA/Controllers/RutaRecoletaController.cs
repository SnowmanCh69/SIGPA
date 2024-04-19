using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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
          string PuntoIncio,
          string PuntoFinalizacion,
          int IdEstadoRuta,
          int IdUsuario,
          int IdVehiculo
        )
        {
            var rutaRecolecta = await rutaRecolectaService.CreateRutaRecolecta(PuntoIncio, PuntoFinalizacion, IdEstadoRuta, IdUsuario, IdVehiculo);
            return CreatedAtAction(nameof(GetRutaRecolecta), new { id = rutaRecolecta.IdRutaRecolecta }, rutaRecolecta);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRutaRecolecta(
          int IdRutaRecolecta,
          string? PuntoIncio,
          string? PuntoFinalizacion,
          int? IdEstadoRuta,
          int? IdUsuario,
          int? IdVehiculo
         )
        {
            var rutaRecolecta = await rutaRecolectaService.UpdateRutaRecolecta(IdRutaRecolecta, PuntoIncio, PuntoFinalizacion, IdEstadoRuta, IdUsuario, IdVehiculo);
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

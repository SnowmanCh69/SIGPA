using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoController(ITipoVehiculoService tipoVehiculoService) : ControllerBase
    {
            [HttpGet]
            public async Task<IActionResult> GetTipoVehiculos()
            {
                IEnumerable<TipoVehiculo> tipoVehiculos = await tipoVehiculoService.GetTiposVehiculos();
                return Ok(tipoVehiculos);
            }

            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetTipoVehiculo(int id)
            {
                TipoVehiculo? tipoVehiculo = await tipoVehiculoService.GetTipoVehiculo(id);
                if (tipoVehiculo == null)
            {
                    return NotFound();
                }
                return Ok(tipoVehiculo);
            }

            [HttpPost]
            public async Task<IActionResult> CreateTipoVehiculo(
                [FromForm][Required] string NombreTipoVehiculo
             )
            {
                var tipoVehiculo = await tipoVehiculoService.CreateTipoVehiculo(NombreTipoVehiculo);
                return CreatedAtAction(nameof(GetTipoVehiculo), new { id = tipoVehiculo.IdTipoVehiculo }, tipoVehiculo);
            }

            [HttpPut]
    
            public async Task<IActionResult> UpdateTipoVehiculo(
               [FromForm][Required] int IdTipoVehiculo,
               [FromForm] string? NombreTipoVehiculo
             )
            {
                var tipoVehiculo = await tipoVehiculoService.UpdateTipoVehiculo(IdTipoVehiculo, NombreTipoVehiculo);
                return Ok(tipoVehiculo);
            }

            [HttpDelete("{id:int}")]
            public async Task<IActionResult> DeleteTipoVehiculo(int id)
            {
                var deletedTipoVehiculo = await tipoVehiculoService.DeleteTipoVehiculo(id);
                if(deletedTipoVehiculo == null)
            {
                    return NotFound();
                }
                return Ok(deletedTipoVehiculo);
            }
     }   
}

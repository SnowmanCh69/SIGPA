using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController (IVehiculoService vehiculoService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetVehiculos()
        {
            IEnumerable<Vehiculo> vehiculos = await vehiculoService.GetVehiculos();
            return Ok(vehiculos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVehiculo(int id)
        {
            Vehiculo? vehiculo = await vehiculoService.GetVehiculo(id);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehiculo
        (
            [FromForm][Required] string Marcavehiculo,
            [FromForm][Required] string Modelovehiculo,
            [FromForm][Required] string Placavehiculo,
            [FromForm][Required] int Tipovehiculo
         )
        {
            var vehiculo = await vehiculoService.CreateVehiculo(Marcavehiculo,Modelovehiculo,Placavehiculo,Tipovehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.IdVehiculo }, vehiculo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehiculo
        (
           [FromForm][Required] int IdVehiculo,
           [FromForm] string? Marcavehiculo,
           [FromForm] string? Modelovehiculo,
           [FromForm] string? Placavehiculo,
           [FromForm] int? Tipovehiculo
          )
        {
            var vehiculo = await vehiculoService.UpdateVehiculo(IdVehiculo, Marcavehiculo, Modelovehiculo, Placavehiculo, Tipovehiculo);
            return Ok(vehiculo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var deletedVehiculo = await vehiculoService.DeleteVehiculo(id);
            if(deletedVehiculo == null) return NotFound();
            return Ok(deletedVehiculo);
        }
    }
}

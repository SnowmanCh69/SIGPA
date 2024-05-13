using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;
using SIGPA.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ControlCalidadController(IControlCalidadService controlCalidadService) : ControllerBase
    {
       

        [HttpGet]
        public async Task<IActionResult> GetControlesCalidad()
        {
            IEnumerable<ControlCalidad> controlesCalidad = await controlCalidadService.GetControlesCalidad();
            return Ok(controlesCalidad);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetControlCalidad(int id)
        {
            ControlCalidad? controlCalidad = await controlCalidadService.GetControlCalidad(id);
            if (controlCalidad == null)
            {
                return NotFound();
            }
            return Ok(controlCalidad);
        }

        [HttpPost]
        public async Task<IActionResult> CreateControlCalidad(

            [FromForm] DateOnly FechaControl,
            [FromForm] int IdUsuario,
            [FromForm] int IdResiduo,
            [FromForm] int IdMetodoControl,
            [FromForm] string Observaciones
            )
        {
            var controlCalidad = await controlCalidadService.CreateControlCalidad(FechaControl, IdUsuario,IdResiduo, IdMetodoControl,Observaciones);
            return CreatedAtAction(nameof(GetControlCalidad), new { id = controlCalidad.IdControlCalidad }, controlCalidad);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateControlCalidad(

          [FromForm][Required] int IdControlCalidad,
          [FromForm] DateOnly? FechaControl,
          [FromForm] int? IdUsuario,
          [FromForm] int? IdResiduo,
          [FromForm] int? IdMetodoControl,
          [FromForm] string? Observaciones
         )
        {
         var controlCalidad = await controlCalidadService.UpdateControlCalidad(IdControlCalidad, FechaControl, IdUsuario, IdResiduo, IdMetodoControl, Observaciones);
         return Ok(controlCalidad);  
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteControlCalidad(int id)
        {
            var deletedControlCalidad = await controlCalidadService.DeleteControlCalidad(id);
            if(deletedControlCalidad == null) return NotFound();
            return Ok(deletedControlCalidad);
        }
    }
}

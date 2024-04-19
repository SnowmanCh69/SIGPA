using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;

namespace SIGPA.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

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
            
            DateTime FechaControl,
            int IdUsuario,
            int IdMetodoControl
            )
        {
            var controlCalidad = await controlCalidadService.CreateControlCalidad(FechaControl, IdUsuario, IdMetodoControl);
            return CreatedAtAction(nameof(GetControlCalidad), new { id = controlCalidad.IdControlCalidad }, controlCalidad);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateControlCalidad(
                       
          int IdControlCalidad,
          DateTime? FechaControl,
          int? IdUsuario,
          int? IdMetodoControl
         )
        {
         var controlCalidad = await controlCalidadService.UpdateControlCalidad(IdControlCalidad, FechaControl, IdUsuario, IdMetodoControl);
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

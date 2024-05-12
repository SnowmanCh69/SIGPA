using Microsoft.AspNetCore.Mvc;
using SIGPA.Helpers;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController (IRolUsuarioService rolUsuarioService): ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetRolesUsuarios()
        {
            IEnumerable<RolUsuario> rolesUsuarios = await rolUsuarioService.GetRolesUsuarios();
            return Ok(rolesUsuarios);
        }

        [HttpGet("{id:int}")]
        
        public async Task<IActionResult> GetRolUsuario(int id)
        {
            RolUsuario? rolUsuario = await rolUsuarioService.GetRolUsuario(id);
            if (rolUsuario == null) return NotFound();
            return Ok(rolUsuario);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRolUsuario(
           [FromForm][Required] string nombreRolUsuario
        )
        {
            var rolUsuario = await rolUsuarioService.CreateRolUsuario(nombreRolUsuario);
            return CreatedAtAction(nameof(GetRolUsuario), new { id = rolUsuario.IdRolUsuario }, rolUsuario);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateRolUsuario(
          [FromForm][Required] int IdRolUsuario,
          [FromForm] string? nombreRolUsuario
        )
        {
           
           var rolUsuario = await rolUsuarioService.UpdateRolUsuario(IdRolUsuario, nombreRolUsuario);
           return Ok(rolUsuario);

        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteRolUsuario(int id)
        {
            var deletedRolUsuario = await rolUsuarioService.DeleteRolUsuario(id);
            if (deletedRolUsuario == null) return NotFound();
            return Ok(deletedRolUsuario);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios = await usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            Usuario? usuario = await usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(
            string NombresUsuario,
            string ApellidosUsuario,
            string EmailUsuario,
            int IdRolUsuario
         )
        {
            var usuario= await usuarioService.CreateUsuario(NombresUsuario, ApellidosUsuario, EmailUsuario, IdRolUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUsuario(
             int IdUsuario,
             string? NombresUsuario,
             string? ApellidosUsuario,
             string? EmailUsuario,
             int? IdRolUsuario
        )
        {
            var usuario = await usuarioService.UpdateUsuario(IdUsuario, NombresUsuario, ApellidosUsuario, EmailUsuario, IdRolUsuario);
            return Ok(usuario);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deletedUsuario = await usuarioService.DeleteUsuario(id);
            if (deletedUsuario == null)
            {
                return NotFound();
            }
            return Ok(deletedUsuario);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SIGPA.Helpers;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

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
            [FromForm][Required] string NombresUsuario,
            [FromForm][Required] string ApellidosUsuario,
            [FromForm][Required] string EmailUsuario,
            [FromForm] string? Username,
            [FromForm][Required] string Password,
            [FromForm][Required] int IdRolUsuario
         )
        {
            // Check if the email is already taken
            Usuario? emailUsuario = await usuarioService.GetUsuarioByEmail(EmailUsuario, IdRolUsuario);
            if (emailUsuario != null) return BadRequest(new { message = "Email is already taken" });


            // Check if the username is already taken
            if (Username != null)
            {
                Usuario? userCheck = await usuarioService.GetUsuarioByUsername(Username, IdRolUsuario);
                if (userCheck != null) return BadRequest(new { message = "Username is already taken" });
            }
            var usuario = await usuarioService.CreateUsuario(NombresUsuario, ApellidosUsuario, EmailUsuario,Username,Password, IdRolUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUsuario(
             [FromForm][Required] int IdUsuario,
             [FromForm] string? NombresUsuario,
             [FromForm] string? ApellidosUsuario,
             [FromForm] string? EmailUsuario,
             [FromForm] string? Username,
             [FromForm] string? Password,
             [FromForm] int? IdRolUsuario
        )
        {
            var usuario = await usuarioService.UpdateUsuario(IdUsuario, NombresUsuario, ApellidosUsuario, EmailUsuario,Username,Password, IdRolUsuario);
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SIGPA.Models;
using SIGPA.Services;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Controllers { 

[Route("api/[controller]")]
[ApiController]

public class AuthController (IUsuarioService usuarioService) : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromForm] AuthRequest authRequest)
        {
            var response = await usuarioService.Authenticate(authRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(
        [FromForm][Required] int IdRolUsuario,
        [FromForm][Required] string NombresUsuario,
        [FromForm][Required] string ApellidosUsuario,
        [FromForm][Required][EmailAddress(ErrorMessage = "Invalid email address")] string EmailUsuario,
        [FromForm] string? Username,
        [FromForm][Required][MaxLength(30)] string Password
    )
    {

        // Check if the email is already taken
        Usuario? emailUser = await usuarioService.GetUsuarioByEmail(EmailUsuario, IdRolUsuario);
        if (emailUser != null) return BadRequest(new { message = "Email is already taken" });

        // Check if the username is already taken
       if (Username != null)
        {
          Usuario? usuario = await usuarioService.GetUsuarioByUsername(Username, IdRolUsuario);
          if (usuario != null) return BadRequest(new { message = "Username is already taken" });
        }

            Usuario response = await usuarioService.CreateUsuario(
            NombresUsuario, 
            ApellidosUsuario, 
            EmailUsuario, 
            Username, 
            Password, 
            IdRolUsuario);

        return Ok(response);
    }
   }
}

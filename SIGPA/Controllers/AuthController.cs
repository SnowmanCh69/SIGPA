using Microsoft.AspNetCore.Mvc;
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
        [FromForm] string ApellidosUsuario,
        [FromForm][Required][EmailAddress(ErrorMessage = "Invalid email address")] string EmailUsuario,
        [FromForm][Required] string? Username,
        [FromForm][Required][MaxLength(30)] string Password
    )
    { 
        var response = await usuarioService.CreateUsuario(
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

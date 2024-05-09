using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SIGPA.Models;
using SIGPA.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SIGPA.Helpers
{
    public class JwtMiddleware(RequestDelegate next, IOptions<AuthSettings> appSettings)
    {
        private readonly AuthSettings _appSettings = appSettings.Value;

        public async Task Invoke(HttpContext context, IUsuarioService usuarioService)
        {
            string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await attachUserToContext(context, usuarioService, token);

            await next(context);
        }

        private async Task attachUserToContext(HttpContext context, IUsuarioService usuarioService, string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                int userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                //Attach user to context on successful JWT validation
                context.Items["Usuario"] = await usuarioService.GetUsuario(userId);
            }
            catch
            {
                //Do nothing if JWT validation fails
                // user is not attached to context so the request won't have access to secure routes
            }
        }
    }
}

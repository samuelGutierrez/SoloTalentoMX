using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string _secretKey;
        private readonly IUsuariosServices _iUsuariosServices;

        public AuthenticationController(IConfiguration config, IUsuariosServices iUsuariosServices)
        {
            _secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            _iUsuariosServices = iUsuariosServices;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto login)
        {
            var oLogin = await _iUsuariosServices.ObtenerUsuario(login);

            if (oLogin != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
                var claims = new ClaimsIdentity();
                //claims.AddClaim(new Claim(ClaimTypes.Name, oLogin..Nombre));
                claims.AddClaim(new Claim(ClaimTypes.Email, oLogin.Correo));
                claims.AddClaim(new Claim(ClaimTypes.Role, oLogin.IdTipoUsuario.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);

                return Ok(new { token = tokencreado });
            }
            else
                return Unauthorized(new { token = "" });
        }
    }
}

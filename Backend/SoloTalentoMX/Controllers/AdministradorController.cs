using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorServices _iAdministradorServices;

        public AdministradorController(IAdministradorServices iAdministradorServices)
        {
            _iAdministradorServices = iAdministradorServices;
        }

        [HttpPost("RegisterAdmin")]
        public async Task<ReturnWebApi> RegisterUser([FromBody] AdministradoresCreateDto dto)
        {
            return await _iAdministradorServices.RegistrarAdministrador(dto);
        }
    }
}

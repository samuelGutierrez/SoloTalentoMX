using Microsoft.AspNetCore.Mvc;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        private readonly ITiendasServices _iTiendasServices;

        public TiendasController(ITiendasServices iTiendasServices)
        {
            _iTiendasServices = iTiendasServices;
        }

        [HttpPost("RegistrarTiendas")]
        public async Task<ReturnWebApi> RegistrarTienda([FromBody] TiendasCreateDto dto)
        {
            return await _iTiendasServices.RegistrarTienda(dto);
        }
    }
}

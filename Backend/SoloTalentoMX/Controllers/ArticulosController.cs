using Microsoft.AspNetCore.Mvc;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosServices _iArticulosServices;

        public ArticulosController(IArticulosServices iArticulosServices)
        {
            _iArticulosServices = iArticulosServices;
        }

        [HttpPost("RegistrarArticulo")]
        public async Task<ReturnWebApi> RegistrarArticulo([FromBody] ArticulosCreateDto dto)
        {
            return await _iArticulosServices.RegistrarArticulos(dto);
        }
    }
}

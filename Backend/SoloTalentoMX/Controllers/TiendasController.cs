using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TiendasController : ControllerBase
    {
        private readonly ITiendasServices _iTiendasServices;
        private readonly IArticulosTiendaService _iArticulosTiendaServices;
        private readonly IClienteArticuloServices _iClienteArticulosTiendaServices;

        public TiendasController(ITiendasServices iTiendasServices, IArticulosTiendaService iArticulosTiendaServices, IClienteArticuloServices iClienteArticulosTiendaServices)
        {
            _iTiendasServices = iTiendasServices;
            _iArticulosTiendaServices = iArticulosTiendaServices;
            _iClienteArticulosTiendaServices = iClienteArticulosTiendaServices;
        }

        [HttpPost("RegistrarTiendas")]
        public async Task<ReturnWebApi> RegistrarTienda([FromBody] TiendasCreateDto dto)
        {
            return await _iTiendasServices.RegistrarTienda(dto);
        }

        [HttpPost("AbastecerTienda")]
        public async Task<ReturnWebApi> AbastecerTienda([FromBody] ArticulosTiendaCreateDto dto)
        {
            //return await _iArticulosTiendaServices.AbastecerTienda(dto);
            return null;
        }

        [HttpPost("Venta")]
        public async Task<ReturnWebApi> VentaTienda([FromBody] VentaCreateDto dto)
        {
            return await _iClienteArticulosTiendaServices.Venta(dto);
        }
    }
}

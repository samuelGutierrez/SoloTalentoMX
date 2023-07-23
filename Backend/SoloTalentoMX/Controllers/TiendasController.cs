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
            return await _iArticulosTiendaServices.AbastecerTienda(dto);
        }

        [HttpPost("Venta")]
        public async Task<ReturnWebApi> VentaTienda([FromBody] VentaCreateDto dto)
        {
            return await _iClienteArticulosTiendaServices.Venta(dto);
        }

        [HttpPut("ActualizarTienda/{id}")]
        public async Task<ReturnWebApi> ActualizarTienda([FromBody] TiendaUpdateDto updateDto, int id)
        {
            return await _iTiendasServices.ActualizarTienda(updateDto, id);
        }

        [HttpDelete("EliminarTienda/{id}")]
        public async Task<ReturnWebApi> EliminarArticulo(int id)
        {
            return await _iTiendasServices.EliminarArticulo(id);
        }

        [HttpGet("ObtenerTiendaxId/{id}")]
        public async Task<TiendasDto> ObtenerTiendaxId(int id)
        {
            return await _iTiendasServices.ObtenerTiendaxId(id);
        }

        [HttpGet("ListaTiendas")]
        public async Task<List<TiendasDto>> ListaTiendas()
        {
            return await _iTiendasServices.ListaTiendas();
        }

        [HttpGet("ArticulosTienda/{idTienda}")]
        public async Task<List<ArticulosDto>> ArticulosTienda(int idTienda)
        {
            return await _iArticulosTiendaServices.ArticulosDeTienda(idTienda);
        }
    }
}

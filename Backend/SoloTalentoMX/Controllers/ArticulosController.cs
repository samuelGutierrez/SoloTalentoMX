using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Services;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPut("ActualizarArticulo/{id}")]
        public async Task<ReturnWebApi> ActualizarArticulo([FromBody] ArticulasUpdateDto updateDto, int id)
        {
            return await _iArticulosServices.ActualizarArticulo(updateDto, id);
        }

        [HttpDelete("EliminarArticulo/{id}")]
        public async Task<ReturnWebApi> EliminarArticulo(int id)
        {
            return await _iArticulosServices.EliminarArticulo(id);
        }

        [HttpGet("ObtenerArticuloxId/{id}")]
        public async Task<ArticulosDto> ObtenerArticuloxId(int id)
        {
            return await _iArticulosServices.ObtenerArticuloxId(id);
        }

        [HttpGet("ListaArticulos")]
        public async Task<List<ArticulosDto>> ListaTiendas()
        {
            return await _iArticulosServices.ListaArticulos();
        }
    }
}

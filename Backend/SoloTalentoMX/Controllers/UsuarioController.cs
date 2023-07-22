using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;

namespace SoloTalentoMX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosServices _iUsuariosService;

        public UsuarioController(IUsuariosServices iUsuariosService)
        {
            _iUsuariosService = iUsuariosService;
        }

        [HttpGet("ObtenerUsuario")]
        public async Task<UsuariosRolDto> ObtenerUsuario(int id)
        {
            return await _iUsuariosService.ObtenerUsuarioxId(id);
        }
    }
}

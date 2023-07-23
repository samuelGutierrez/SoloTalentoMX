using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface ITiendasServices
    {
        Task<ReturnWebApi> RegistrarTienda(TiendasCreateDto dto);
        Task<List<TiendasDto>> ListaTiendas();
        Task<TiendasDto> ObtenerTiendaxId(int id);
        Task<ReturnWebApi> ActualizarTienda(TiendaUpdateDto updateDto, int id);
        Task<ReturnWebApi> EliminarArticulo(int id);
    }
}

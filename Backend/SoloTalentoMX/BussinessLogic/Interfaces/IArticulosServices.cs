using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface IArticulosServices
    {
        Task<ReturnWebApi> RegistrarArticulos(ArticulosCreateDto dto);
        Task<List<ArticulosDto>> ListaArticulos();
        Task<ArticulosDto> ObtenerArticuloxId(int id);
        Task<ReturnWebApi> ActualizarArticulo(ArticulasUpdateDto updateDto, int id);
        Task<ReturnWebApi> EliminarArticulo(int id);
    }
}

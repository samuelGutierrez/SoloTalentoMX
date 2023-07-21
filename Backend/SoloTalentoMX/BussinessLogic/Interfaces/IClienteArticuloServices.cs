using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface IClienteArticuloServices
    {
        Task<ReturnWebApi> Venta(List<VentaCreateDto> dto);
    }
}

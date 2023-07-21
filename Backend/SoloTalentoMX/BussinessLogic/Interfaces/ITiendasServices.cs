using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface ITiendasServices
    {
        Task<ReturnWebApi> RegistrarTienda(TiendasCreateDto dto);
    }
}

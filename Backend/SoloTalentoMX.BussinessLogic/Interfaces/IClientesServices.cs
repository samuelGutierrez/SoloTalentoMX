using SoloTalentoMX.BussinessLogic.Dto;
using SoloTalentoMX.BussinessLogic.Utility;

namespace SoloTalentoMX.BussinessLogic.Interfaces
{
    public interface IClientesServices
    {
        Task<ReturnWebApi> RegistrarUsuario(ClientesCreateDto dto);
    }
}

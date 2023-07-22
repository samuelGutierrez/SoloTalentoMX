using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface IClientesServices
    {
        Task<ReturnWebApi> RegistrarUsuario(ClientesCreateDto dto);
        Task<List<ClientesDto>> ListaClientes();
    }
}

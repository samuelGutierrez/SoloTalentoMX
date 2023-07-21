using SoloTalentoMX.Api.BussinessLogic.Dto;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface IUsuariosServices
    {
        Task<bool> CrearUsuario(UsuariosCreateDto dto);
    }
}

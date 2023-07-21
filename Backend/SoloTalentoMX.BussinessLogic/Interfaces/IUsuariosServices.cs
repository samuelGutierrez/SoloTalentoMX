using SoloTalentoMX.BussinessLogic.Dto;

namespace SoloTalentoMX.BussinessLogic.Interfaces
{
    public interface IUsuariosServices
    {
        Task<bool> CrearUsuario(UsuariosCreateDto dto);
    }
}

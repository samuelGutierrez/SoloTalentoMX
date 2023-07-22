using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Data.Domain;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface IUsuariosServices
    {
        Task<bool> CrearUsuario(UsuariosCreateDto dto);
        Task<Usuarios> ObtenerUsuario(UsuarioLoginDto login);
    }
}

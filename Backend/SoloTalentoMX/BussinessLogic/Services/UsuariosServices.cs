using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IGeneric<Usuarios> _igUsuarios;

        public UsuariosServices(IGeneric<Usuarios> igUsuarios)
        {
            _igUsuarios = igUsuarios;
        }

        public async Task<bool> CrearUsuario(UsuariosCreateDto dto)
        {
            try
            {
                var saveData = new Usuarios()
                {
                    IdCliente = dto.IdCliente,
                    IdAdministrador = dto.IdAdministrador,
                    IdTipoUsuario = dto.IdTipoUsuario,
                    Correo = dto.Correo,
                    Password = dto.Password
                };

                var exitoso = await _igUsuarios.CreateAsync(saveData);

                if (exitoso != null)
                    return true;
                return false;

            }
            catch (Exception ex) { throw ex; }
        }
    }
}

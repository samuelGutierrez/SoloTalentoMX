using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class AdministradorServices : IAdministradorServices
    {
        private readonly IGeneric<Administradores> _igAdministradores;

        private readonly IUsuariosServices _iUsuariosServices;

        public AdministradorServices(IGeneric<Administradores> igAdministradores, IUsuariosServices iUsuariosServices)
        {
            _igAdministradores = igAdministradores;
            _iUsuariosServices = iUsuariosServices;
        }

        public async Task<ReturnWebApi> RegistrarAdministrador(AdministradoresCreateDto dto)
        {
            try
            {
                var saveData = new Administradores()
                {
                    Apellido = dto.Apellido,
                    Direccion = dto.Direccion,
                    Nombre = dto.Nombre,
                };

                var exitoso = await _igAdministradores.CreateAsync(saveData);

                if (exitoso != null)
                {
                    var saveDataUsuario = new UsuariosCreateDto()
                    {
                        IdAdministrador = exitoso.Id,
                        IdTipoUsuario = (int)Enumerations.eTypeUser.Administrador,
                        Correo = dto.Correo,
                        Password = dto.Password
                    };

                    if (await _iUsuariosServices.CrearUsuario(saveDataUsuario))
                        return new ReturnWebApi<Administradores>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                    return new ReturnWebApi<Administradores>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
                }
                return new ReturnWebApi<Administradores>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<Administradores>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }
    }
}

using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class ClientesServices : IClientesServices
    {
        private readonly IGeneric<Clientes> _igClientes;
        private readonly IUsuariosServices _iUsuariosService;

        public ClientesServices(IGeneric<Clientes> igClientes, IUsuariosServices iUsuariosService)
        {
            _igClientes = igClientes;
            _iUsuariosService = iUsuariosService;
        }

        public async Task<ReturnWebApi> RegistrarUsuario(ClientesCreateDto dto)
        {
            try
            {
                var saveData = new Clientes()
                {
                    Apellido = dto.Apellido,
                    Direccion = dto.Direccion,
                    Nombre = dto.Nombre,
                };

                var exitoso = await _igClientes.CreateAsync(saveData);

                if (exitoso != null)
                {
                    var saveDataUsuario = new UsuariosCreateDto()
                    {
                        IdCliente = exitoso.Id,
                        IdTipoUsuario = (int)Enumerations.eTypeUser.Cliente,
                        Correo = dto.Correo,
                        Password = dto.Password
                    };

                    if (await _iUsuariosService.CrearUsuario(saveDataUsuario))
                        return new ReturnWebApi<Clientes>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                    return new ReturnWebApi<Clientes>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
                }
                return new ReturnWebApi<Clientes>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<Clientes>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }
    }
}

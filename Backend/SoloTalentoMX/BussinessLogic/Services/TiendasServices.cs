using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class TiendasServices : ITiendasServices
    {
        private readonly IGeneric<Tiendas> _igTiendas;

        public TiendasServices(IGeneric<Tiendas> igTiendas)
        {
            _igTiendas = igTiendas;
        }

        public async Task<ReturnWebApi> RegistrarTienda(TiendasCreateDto dto)
        {
            try
            {
                var saveData = new Tiendas()
                {
                    Sucursal = dto.Sucursal,
                    Direccion = dto.Direccion,
                    Imagen = dto.Imagen
                };

                var exitoso = await _igTiendas.CreateAsync(saveData);

                if (exitoso != null)
                    return new ReturnWebApi<Tiendas>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                return new ReturnWebApi<Tiendas>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<Tiendas>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }

    }
}

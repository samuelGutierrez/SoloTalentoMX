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
                byte[] imageData;

                // Lee la imagen del archivo y conviértela a bytes
                using (var stream = new FileStream(dto.Imagen, FileMode.Open))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                }

                var saveData = new Tiendas()
                {
                    Sucursal = dto.Sucursal,
                    Direccion = dto.Direccion,
                    Imagen = imageData
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

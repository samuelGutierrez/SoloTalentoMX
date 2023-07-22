using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class ArticulosServices : IArticulosServices
    {
        private readonly IGeneric<Articulos> _igArticulos;

        public ArticulosServices(IGeneric<Articulos> igArticulos)
        {
            _igArticulos = igArticulos;
        }

        public async Task<ReturnWebApi> RegistrarArticulos(ArticulosCreateDto dto)
        {
            try
            {
                //byte[] imageData;

                // Lee la imagen del archivo y conviértela a bytes
                //using (var stream = new FileStream(dto.Imagen, FileMode.Open))
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        stream.CopyTo(memoryStream);
                //        imageData = memoryStream.ToArray();
                //    }
                //}

                var saveData = new Articulos()
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    Imagen = dto.Imagen,
                    Precio = dto.Precio,
                    Stock = dto.Stock
                };

                var exitoso = await _igArticulos.CreateAsync(saveData);

                if (exitoso != null)
                    return new ReturnWebApi<Tiendas>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                return new ReturnWebApi<Tiendas>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<Tiendas>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }

        
    }
}

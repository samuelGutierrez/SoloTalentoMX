using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class ArticulosTiendaService : IArticulosTiendaService
    {
        private readonly IGeneric<ArticuloTienda> _igArticuloTienda;

        public ArticulosTiendaService(IGeneric<ArticuloTienda> igArticuloTienda)
        {
            _igArticuloTienda = igArticuloTienda;
        }

        public async Task<ReturnWebApi> AbastecerTienda(ArticulosTiendaCreateDto dto)
        {
            try
            {
                var saveData = new ArticuloTienda
                {
                    IdArticulo = dto.IdArticulo,
                    IdTienda = dto.IdTienda,
                    Activo = dto.Activo,
                    Date = DateTime.Now
                };

                var exitoso = await _igArticuloTienda.CreateAsync(saveData);

                if (exitoso != null)
                    return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<ArticuloTienda>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }
    }
}

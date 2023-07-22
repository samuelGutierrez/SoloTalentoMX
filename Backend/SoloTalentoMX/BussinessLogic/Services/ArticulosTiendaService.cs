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
        private readonly IGeneric<Articulos> _igArticulos;

        public ArticulosTiendaService(IGeneric<ArticuloTienda> igArticuloTienda, IGeneric<Articulos> igArticulos)
        {
            _igArticuloTienda = igArticuloTienda;
            _igArticulos = igArticulos;
        }

        public async Task<ReturnWebApi> AbastecerTienda(ArticulosTiendaCreateDto dto)
        {
            try
            {
                List<ArticuloTienda> listaArticuloTiendas = new List<ArticuloTienda>();

                for (int i = 0; i < dto.Articulos.Count; i++)
                {
                    var saveData = new ArticuloTienda
                    {
                        IdArticulo = dto.Articulos[i].IdArticulo,
                        IdTienda = dto.IdTienda,
                        StockTienda = dto.Articulos[i].StockTienda,
                        Date = DateTime.Now
                    };

                    //Actualizar el stock del articulo para abastecer la tienda
                    var currentArticulo = _igArticulos.Search(x => x.Id == dto.Articulos[i].IdArticulo);

                    if ((currentArticulo.Stock -= dto.Articulos[i].StockTienda) < 0)
                        return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoAbastecioTienda, Enumerations.eResponse.Error);
                    else
                    {
                        var exitoso = await _igArticuloTienda.CreateAsync(saveData);
                        _igArticulos.Modify(currentArticulo);

                        if (exitoso != null)
                            return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                        return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
                    }
                }
                return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<ArticuloTienda>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }
    }
}

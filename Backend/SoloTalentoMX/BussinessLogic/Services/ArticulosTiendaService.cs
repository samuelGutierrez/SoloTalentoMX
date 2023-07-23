using Microsoft.EntityFrameworkCore;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Data;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class ArticulosTiendaService : IArticulosTiendaService
    {
        private readonly IGeneric<ArticuloTienda> _igArticuloTienda;
        private readonly IGeneric<Articulos> _igArticulos;
        private readonly IGeneric<Tiendas> _igTiendas;

        private Context _context;

        public ArticulosTiendaService(IGeneric<ArticuloTienda> igArticuloTienda, IGeneric<Articulos> igArticulos,
            IGeneric<Tiendas> igTiendas, Context context)
        {
            _igArticuloTienda = igArticuloTienda;
            _igArticulos = igArticulos;
            _igTiendas = igTiendas;
            _context = context;
        }

        public async Task<ReturnWebApi> AbastecerTienda(ArticulosTiendaCreateDto dto)
        {
            try
            {
                for (int i = 0; i < dto.Articulos.Count; i++)
                {
                    var currentArticuloTienda = _igArticuloTienda.Search(x => x.IdTienda == dto.IdTienda && x.IdArticulo == dto.Articulos[i].IdArticulo);

                    //Actualizar el stock del articulo para abastecer la tienda
                    var currentArticulo = _igArticulos.Search(x => x.Id == dto.Articulos[i].IdArticulo);

                    if (currentArticuloTienda != null)
                    {
                        currentArticuloTienda.StockTienda += dto.Articulos[i].StockTienda;
                        currentArticuloTienda.Date = DateTime.Now;

                        if ((currentArticulo.Stock -= dto.Articulos[i].StockTienda) < 0)
                            return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoAbastecioTienda, Enumerations.eResponse.Error);
                        else
                        {
                            var exitoso = _igArticuloTienda.Modify(currentArticuloTienda);
                            _igArticulos.Modify(currentArticulo);

                            if (exitoso != null)
                                return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                            return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
                        }
                    }
                    else
                    {
                        var saveData = new ArticuloTienda
                        {
                            IdArticulo = dto.Articulos[i].IdArticulo,
                            IdTienda = dto.IdTienda,
                            StockTienda = dto.Articulos[i].StockTienda,
                            Date = DateTime.Now
                        };

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
                }
                return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<ArticuloTienda>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }

        public async Task<List<ArticulosDto>> ArticulosDeTienda(int idTienda)
        {
            try
            {
                var listArticulosXTienda = await (from at in _context.ArticuloTienda
                                                  join a in _context.Articulos on at.IdArticulo equals a.Id
                                                  where at.IdTienda == idTienda
                                                  select new ArticulosDto
                                                  {
                                                      Id = at.IdArticulo,
                                                      Codigo = a.Codigo,
                                                      Descripcion = a.Descripcion,
                                                      Imagen = a.Imagen,
                                                      Precio = a.Precio,
                                                      Stock = at.StockTienda
                                                  }).ToListAsync();

                return listArticulosXTienda;
            }
            catch (CustomExceptions ex) { throw ex; }
        }
    }
}

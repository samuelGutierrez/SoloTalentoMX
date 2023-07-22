using oloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Utility;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class ClienteArticuloServices : IClienteArticuloServices
    {
        private readonly IGeneric<ClienteArticulo> _igClienteArticulo;
        private readonly IGeneric<ArticuloTienda> _igArticuloTienda;

        public ClienteArticuloServices(IGeneric<ClienteArticulo> igClienteArticulo, IGeneric<ArticuloTienda> igArticuloTienda)
        {
            _igClienteArticulo = igClienteArticulo;
            _igArticuloTienda = igArticuloTienda;
        }

        public async Task<ReturnWebApi> Venta(VentaCreateDto dto)
        {
            try
            {
                List<ClienteArticulo> listaVentas = new List<ClienteArticulo>();
                List<ArticuloTienda> listaInventario = new List<ArticuloTienda>();

                for (int i = 0; i < dto.Articulos.Count; i++)
                {
                    var articuloTienda = _igArticuloTienda.Search(x => x.IdTienda == dto.IdTienda && x.IdArticulo == dto.Articulos[i].IdArticulo);
                    var saveData = new ClienteArticulo()
                    {
                        IdCliente = dto.IdCliente,
                        IdArticuloTienda = articuloTienda.Id,
                        Date = DateTime.Now,
                        CantidadCompra = dto.Articulos[i].Cantidad
                    };

                    listaVentas.Add(saveData);

                    if ((articuloTienda.StockTienda -= dto.Articulos[i].Cantidad) < 0)
                        return new ReturnWebApi<ArticuloTienda>(Enumerations.eMessagesClient.NoVenta, Enumerations.eResponse.Error);
                    _igArticuloTienda.Modify(articuloTienda);
                }

                var exitoso = _igClienteArticulo.AddRange(listaVentas);

                if (exitoso != null)
                    return new ReturnWebApi<ClienteArticulo>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                return new ReturnWebApi<ClienteArticulo>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<ClienteArticulo>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }
    }
}

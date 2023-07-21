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

        public ClienteArticuloServices(IGeneric<ClienteArticulo> igClienteArticulo)
        {
            _igClienteArticulo = igClienteArticulo;
        }

        public async Task<ReturnWebApi> Venta(List<VentaCreateDto> dto)
        {
            try
            {
                List<ClienteArticulo> listaVentas = new List<ClienteArticulo>();

                for (int i = 0; i < dto.Count; i++)
                {
                    var saveData = new ClienteArticulo()
                    {
                        IdCliente = dto[i].IdCliente,
                        IdArticuloTienda = dto[i].IdArticuloTienda,
                        Date = DateTime.Now
                    };

                    listaVentas.Add(saveData);
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

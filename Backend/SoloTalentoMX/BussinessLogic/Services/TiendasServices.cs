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
    public class TiendasServices : ITiendasServices
    {
        private readonly IGeneric<Tiendas> _igTiendas;
        private readonly IGeneric<ArticuloTienda> _igArticuloTienda;

        private readonly Context _context;

        public TiendasServices(IGeneric<Tiendas> igTiendas, Context context, IGeneric<ArticuloTienda> igArticuloTienda)
        {
            _igTiendas = igTiendas;
            _context = context;
            _igArticuloTienda = igArticuloTienda;
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

        public async Task<List<TiendasDto>> ListaTiendas()
        {
            var listaArticulos = await (from a in _context.Tiendas
                                        select new TiendasDto
                                        {
                                            Id = a.Id,
                                            Direccion = a.Direccion,
                                            Imagen = a.Imagen,
                                            Sucursal = a.Sucursal
                                        }).ToListAsync();
            return listaArticulos;
        }

        public async Task<TiendasDto> ObtenerTiendaxId(int id)
        {
            var articulo = (from a in _context.Tiendas
                            where a.Id == id
                            select new TiendasDto
                            {
                                Id = a.Id,
                                Direccion = a.Direccion,
                                Imagen = a.Imagen,
                                Sucursal = a.Sucursal
                            }).FirstOrDefault();
            return articulo;
        }

        public async Task<ReturnWebApi> ActualizarTienda(TiendaUpdateDto updateDto, int id)
        {
            try
            {
                var currentTienda = _igTiendas.Search(x => x.Id == id);

                currentTienda.Sucursal = updateDto.Sucursal;
                currentTienda.Direccion = updateDto.Direccion;
                currentTienda.Imagen = updateDto.Imagen;

                if (_igTiendas.Modify(currentTienda))
                    return new ReturnWebApi<Tiendas>(Enumerations.eMessagesClient.Guardado, Enumerations.eResponse.Success);
                return new ReturnWebApi<Tiendas>(Enumerations.eMessagesClient.NoGuardado, Enumerations.eResponse.Warning);
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<Tiendas>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }

        public async Task<ReturnWebApi> EliminarArticulo(int id)
        {
            try
            {
                var currentTienda = _igTiendas.Search(x => x.Id == id);
                var articuloTienda = _igArticuloTienda.List().Where(x => x.IdTienda == id).ToList();

                if (articuloTienda.Count > 0)
                    return new ReturnWebApi<Articulos>(Enumerations.eMessagesClient.NoEliminacion, Enumerations.eResponse.Warning);
                else
                {
                    await _igTiendas.RemoveAsync(currentTienda);
                    return new ReturnWebApi<Articulos>(Enumerations.eMessagesClient.Eliminacion, Enumerations.eResponse.Success);
                }
            }
            catch (CustomExceptions ex) { return new ReturnWebApi<Articulos>(ex.CodeMessageClient, ex.Response, ex.Tags); }
        }
    }
}

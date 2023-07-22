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
    public class ArticulosServices : IArticulosServices
    {
        private readonly IGeneric<Articulos> _igArticulos;
        private readonly Context _context;

        public ArticulosServices(IGeneric<Articulos> igArticulos, Context context)
        {
            _igArticulos = igArticulos;
            _context = context;
        }

        public async Task<ReturnWebApi> RegistrarArticulos(ArticulosCreateDto dto)
        {
            try
            {
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

        public async Task<List<ArticulosDto>> ListaArticulos()
        {
            var listaArticulos = await (from a in _context.Articulos
                                        select new ArticulosDto
                                        {
                                            Id = a.Id,
                                            Codigo = a.Codigo,
                                            Descripcion = a.Descripcion,
                                            Imagen = a.Imagen,
                                            Precio = a.Precio,
                                            Stock = a.Stock,
                                        }).ToListAsync();
            return listaArticulos;
        }

        public async Task<ArticulosDto> ObtenerArticuloxId(int id)
        {
            var articulo = (from a in _context.Articulos
                            where a.Id == id
                            select new ArticulosDto
                            {
                                Id = a.Id,
                                Codigo = a.Codigo,
                                Descripcion = a.Descripcion,
                                Imagen = a.Imagen,
                                Precio = a.Precio,
                                Stock = a.Stock,
                            }).FirstOrDefault();
            return articulo;
        }
    }
}

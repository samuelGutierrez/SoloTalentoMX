using Microsoft.EntityFrameworkCore;
using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Data.Data;
using SoloTalentoMX.Data.Domain;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IGeneric<Usuarios> _igUsuarios;
        private readonly Context _context;

        public UsuariosServices(IGeneric<Usuarios> igUsuarios, Context context)
        {
            _igUsuarios = igUsuarios;
            _context = context;
        }

        public async Task<bool> CrearUsuario(UsuariosCreateDto dto)
        {
            try
            {
                var saveData = new Usuarios()
                {
                    IdCliente = dto.IdCliente,
                    IdAdministrador = dto.IdAdministrador,
                    IdTipoUsuario = dto.IdTipoUsuario,
                    Correo = dto.Correo,
                    Password = dto.Password
                };

                var exitoso = await _igUsuarios.CreateAsync(saveData);

                if (exitoso != null)
                    return true;
                return false;

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<Usuarios> ObtenerUsuario(UsuarioLoginDto login)
        {
            try
            {
                return await _igUsuarios.SearchAsync(x => x.Correo == login.Correo && x.Password == login.Password);
            }
            catch (CustomExceptions) { throw; }
        }

        public async Task<UsuariosRolDto> ObtenerUsuarioxId(int id)
        {
            var currentUser = await (from u in _context.Usuarios
                                     where u.Id == id
                                     select new UsuariosRolDto
                                     {
                                         Id = u.Id,
                                         IdTipoUsuario = u.IdTipoUsuario
                                     }).FirstOrDefaultAsync();

            return currentUser;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloTalentoMX.BussinessLogic.Dto
{
    public class UsuariosDto
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdAdministrador { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class UsuariosCreateDto
    {
        public int? IdCliente { get; set; }
        public int? IdAdministrador { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}

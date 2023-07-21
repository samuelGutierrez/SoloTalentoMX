using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloTalentoMX.Data.Domain
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdAdministrador { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Clientes Clientes { get; set; }

        [ForeignKey("IdAdministrador")]
        public virtual Administradores Administradores { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public virtual TipoUsuarios TipoUsuarios { get; set; }
    }
}

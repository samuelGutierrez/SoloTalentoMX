using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloTalentoMX.Data.Domain
{
    public class ClienteArticulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdArticuloTienda { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Clientes Clientes { get; set; }

        [ForeignKey("IdArticuloTienda")]
        public virtual ArticuloTienda ArticuloTienda { get; set; }
    }
}

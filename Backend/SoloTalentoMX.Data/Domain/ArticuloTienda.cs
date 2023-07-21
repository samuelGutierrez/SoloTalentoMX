using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloTalentoMX.Data.Domain
{
    public class ArticuloTienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdTienda { get; set; }
        public int IdArticulo { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("IdTienda")]
        public virtual Tiendas Tiendas { get; set; }

        [ForeignKey("IdArticulo")]
        public virtual Articulos Articulos { get; set; }

        public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; }
    }
}

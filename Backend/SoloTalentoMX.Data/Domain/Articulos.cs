using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloTalentoMX.Data.Domain
{
    public class Articulos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public decimal Precion { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<ArticuloTienda> ArticuloTiendas { get; set; }
    }
}

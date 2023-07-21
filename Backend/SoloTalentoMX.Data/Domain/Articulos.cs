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
        public byte[] Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<ArticuloTienda> ArticuloTiendas { get; set; }
    }
}

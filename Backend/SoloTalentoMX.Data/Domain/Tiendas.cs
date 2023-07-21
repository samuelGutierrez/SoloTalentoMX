using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloTalentoMX.Data.Domain
{
    public class Tiendas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public byte[] Imagen { get; set; }

        public virtual ICollection<ArticuloTienda> ArticulosTienda { get; set; }
    }
}

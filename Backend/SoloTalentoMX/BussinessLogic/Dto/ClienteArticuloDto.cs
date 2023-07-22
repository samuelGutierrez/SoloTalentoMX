namespace SoloTalentoMX.Api.BussinessLogic.Dto
{
    public class ClienteArticuloDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdArticuloTienda { get; set; }
        public DateTime Date { get; set; }
    }

    public class VentaCreateDto
    {
        public int IdCliente { get; set; }
        public int IdTienda { get; set; }
        public List<ArticulosVenta> Articulos { get; set; }
    }

    public class ArticulosVenta
    {
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
    }
}

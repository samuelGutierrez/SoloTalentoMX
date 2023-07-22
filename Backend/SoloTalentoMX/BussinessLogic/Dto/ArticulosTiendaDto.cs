namespace SoloTalentoMX.Api.BussinessLogic.Dto
{
    public class ArticulosTiendaDto
    {
        public int Id { get; set; }
        public int IdTienda { get; set; }
        public int IdArticulo { get; set; }
        public DateTime Date { get; set; }
        public int StockTienda { get; set; }
    }

    public class ArticulosTiendaCreateDto
    {
        public int IdTienda { get; set; }
        public List<ArticuloDto> Articulos { get; set; }
    }

    public class ArticuloDto
    {
        public int IdArticulo { get; set; }
        public int StockTienda { get; set; }
    }
}

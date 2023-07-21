namespace SoloTalentoMX.Api.BussinessLogic.Dto
{
    public class ArticulosTiendaDto
    {
        public int Id { get; set; }
        public int IdTienda { get; set; }
        public int IdArticulo { get; set; }
        public DateTime Date { get; set; }
        public bool Activo { get; set; }
    }

    public class ArticulosTiendaCreateDto
    {
        public int IdTienda { get; set; }
        public int IdArticulo { get; set; }
        public bool Activo { get; set; }
    }
}

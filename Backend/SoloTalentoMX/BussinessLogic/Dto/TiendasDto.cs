namespace SoloTalentoMX.Api.BussinessLogic.Dto
{
    public class TiendasDto
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
    }

    public class TiendasCreateDto
    {
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
    }
}

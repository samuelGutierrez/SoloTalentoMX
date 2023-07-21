namespace SoloTalentoMX.Api.BussinessLogic.Dto
{
    public class AdministradoresDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
    }

    public class AdministradoresCreateDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}

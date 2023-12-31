﻿namespace SoloTalentoMX.Api.BussinessLogic.Dto
{
    public class ArticulosDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public class ArticulosCreateDto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class InsertTiendaModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public bool? Activa { get; set; }
        public string Region { get; set; }
    }

    public class GetTiendaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public bool? Activa { get; set; }
        public string Region { get; set; }
        public DateTime? UltimaVisita { get; set; }
        public decimal? NPS { get; set; }
        public decimal? Fillfoundrate { get; set; }
        public decimal? DamageRate { get; set; }
        public decimal? OutOfStock { get; set; }
        public decimal? ComplaintResolution { get; set; }
    }
}

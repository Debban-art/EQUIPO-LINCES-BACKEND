namespace EQUIPO_LINCES_BACKEND.Models
{
    public class insert_pv
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Region { get; set; }
        public string UltimaVisita { get; set; }
        public double NPS { get; set; }
        public double Fillfoundrate { get; set; }
        public double DamageRate { get; set; }
        public double OutOfStock { get; set; }
        public double ComplaintResolution { get; set; }
    }


    public class get_pv
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Region { get; set; }
        public string UltimaVisita { get; set; }
        public double NPS { get; set; }
        public double Fillfoundrate { get; set; }
        public double DamageRate { get; set; }
        public double OutOfStock { get; set; }
        public double ComplaintResolution { get; set; }

    }

    public class delete_pv
    {
        public int id { get; set; }
    }

    public class update_pv
    {
        public int id { get; set; }
        public string UltimaVisita { get; set; }
        public double NPS { get; set; }
        public double Fillfoundrate { get; set; }
        public double DamageRate { get; set; }
        public double OutOfStock { get; set; }
        public double ComplaintResolution { get; set; }
    }
}
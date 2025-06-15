namespace EQUIPO_LINCES_BACKEND.Models
{
    public class RegistrarImagenVisita //INSERT
    {
        //PARAMETROS
        public int Id_Visita { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
    }

    public class ActualizarAnalisisImagen //PUT UPDATE
    {
        //PARAMETROS
        public int ImagenId { get; set; }
        public string AnalisisTexto { get; set; }
        public string Etiquetas { get; set; }
    }
    public class ObtenerImagenesPorVisita //GET
    {
        public int ImagenId { get; set; }
        public int Id_Visita { get; set; }
        public string Url { get; set; }
        public string FechaSubida { get; set; }
        public string Tipo { get; set; }
        public string AnalisisTexto { get; set; }
        public string Etiquetas { get; set; }
    }
}
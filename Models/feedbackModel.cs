namespace EQUIPO_LINCES_BACKEND.Models
{
    public class InsertFeedbackModel
    {
        public int Id_PuntoVenta { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string AnalisisIA { get; set; }
    }

    public class GetFeedbackModel
    {
        public int FeedbackId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string AnalisisIA { get; set; }
        public string Fecha { get; set; }
    }


}

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class RegistrarImagenVisita //INSERT
    {
        //PARAMETROS
        public int Id_Visita { get; set; }
    }

    public class ActualizarAnalisisImagen //PUT UPDATE
    {
        public int RutaId { get; set; }
    }
    public class ObtenerImagenesPorVisita //GET
    {
        public int Id { get; set; }
        public int Orden { get; set; }
    }
}
namespace EQUIPO_LINCES_BACKEND.Models
{
    public class GetDetalleVentasModel
    {
        public int RutaTiendaId { get; set; }
        public int RutaId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public int Orden { get; set; }
    }

    public class InsertDetalleVentaModel
    {
        public int RutaId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public int Orden { get; set; }
    }
    public class UpdateDetalleVentaModel
    {
        public int Id { get; set; }
        public int Orden { get; set; }
    }
}

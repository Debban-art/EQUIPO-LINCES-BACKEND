using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class InsertVisitasProgramadaModel
    {
        public int UsuarioId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public string FechaProgramada { get; set; }
        public int Id_Ruta { get; set; }
        public int NotificacionEnviada { get; set; }
        public int Confirmada { get; set; }
    }

    public class GetVisitasProgramadasModel
    {
        public int VisitaProgramadaId { get; set; }
        public int UsuarioId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public string FechaProgramada { get; set; }
        public int Id_Ruta { get; set; }
        public int NotificacionEnviada { get; set; }
        public int Confirmada { get; set; }
    }

    public class UpdateVisitasProgramadasModel
    {
                public int VisitaProgramadaId { get; set; }
       
        public string FechaProgramada { get; set; }
        public int Id_Ruta { get; set; }
      
    }
}
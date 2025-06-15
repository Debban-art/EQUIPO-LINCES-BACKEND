using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class GetHistorialNotificacionModel
    {
        public int HitorialId { get; set; }
        public int Id_Notificacion { get; set; }
        public string EnviadaEn { get; set; }
        public int Exito { get; set; }
        public string Error { get; set; }
    }

    public class MarcarNotificacionEnviadaModel
    {
        public int NotificacionId { get; set; }
        public int Exito { get; set; }
        public string Error { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class InsertNotificacionModel
    {
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Mensaje { get; set; }
        public string Canal { get; set; }

    }
    public class GetNotificacionModel
    {
        public int NotificacionId { get; set; }
        
public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Mensaje { get; set; }
        public string Enviada { get; set; }
        public string Fecha { get; set; }
        public string Canal { get; set; }
    }

}
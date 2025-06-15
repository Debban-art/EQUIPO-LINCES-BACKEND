using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class GetRutasModel
    {
        public int RutaId { get; set; }
        public string Nombre { get; set; }
    }

    public class InsertRutasModel
    {
        public string Nombre { get; set; }
    }
    public class UpdateRutasNombre
    {
        public int RutaId { get; set; }
        public string Nombre { get; set; }
    }
}
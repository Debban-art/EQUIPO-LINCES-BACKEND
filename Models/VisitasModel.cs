using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class GetVisitasModel
    {
        public int VisitaId { get; set; }
        public int UsuarioId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public string FechaHora { get; set; }
        public string Coordenadas { get; set; }
        public string Notas { get; set; }
        public string VozTexto { get; set; }
        public string Clima { get; set; }
        public int AsistenciaConfirmada { get; set; }
    }

    public class InsertVisitasModel
    {
        public int UsuarioId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public string Coordenadas { get; set; }
        public string Notas { get; set; }
        public string VozTexto { get; set; }
        public string Clima { get; set; }
        public int AsistenciaConfirmada { get; set; }

    }

    public class UpdateVisitasModel
    {
         public int VisitaId { get; set; }
        public int UsuarioId { get; set; }
        public int Id_PuntoVenta { get; set; }
        public string Coordenadas { get; set; }
        public string Notas { get; set; }
        public string VozTexto { get; set; }
        public string Clima { get; set; }
        public int AsistenciaConfirmada { get; set; }
    }
}
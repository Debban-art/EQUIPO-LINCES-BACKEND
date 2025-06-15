using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIPO_LINCES_BACKEND.Models
{
    public class LoginUsuarioModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }
public class LoginRequestModel
{
    public string Nombre { get; set; }
    public string ContrasenaHash { get; set; }
}


}
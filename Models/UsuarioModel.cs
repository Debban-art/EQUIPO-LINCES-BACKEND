namespace EQUIPO_LINCES_BACKEND.Models
{
    public class InsertUsuarioModel
    {
        public string Nombre {get; set;}
        public string ContrasenaHash {get; set;}
        public string Pais {get; set;}
        public string Estado {get; set;}
        public string Region { get; set; }
        public string Municipio { get; set; }
        public string Rol {get; set;}
    }

    public class GetUsuarioModel
    {
        public int UsuarioId {get; set;}
        public string Nombre {get; set;}
        public string ContrasenaHash {get; set;}
        public string Pais {get; set;}
        public string Estado {get; set;}
        public string Region { get; set; }
        public string Municipio { get; set; }
        public string Rol {get; set;}

    }

    public class UpdateUsuarioModel
    {
        public int Id {get; set;}
        public string NombreUsuario {get; set;}
        public string Password {get; set;}
        public int IdPerfil {get; set;}
        public int Activo {get; set;}
        public int IdUsuario {get; set;}
    }
}
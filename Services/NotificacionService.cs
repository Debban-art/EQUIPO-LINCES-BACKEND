using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using EQUIPO_LINCES_BACKEND.DataContext;
using EQUIPO_LINCES_BACKEND.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace EQUIPO_LINCES_BACKEND.Services
{
    public class NotificacionService
    {
      private readonly string connection;

        public NotificacionService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<GetNotificacionModel> GetNotificacion(int usuarioId)
{
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    List<GetNotificacionModel> lista = new List<GetNotificacionModel>();

    // Crear y agregar el parámetro
    ArrayList parametros = new ArrayList
    {
        new SqlParameter
        {
            ParameterName = "UsuarioId",
            SqlDbType = SqlDbType.Int,
            Value = usuarioId
        }
    };

    try
    {
        DataSet ds = dac.Fill("sp_ObtenerNotificacionesPendientes", parametros);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lista.Add(new GetNotificacionModel
                {
                    NotificacionId = int.Parse(dr["NotificacionId"].ToString()),
                    UsuarioId = int.Parse(dr["UsuarioId"].ToString()),
                    Tipo = dr["Tipo"].ToString(),
                    Mensaje = dr["Mensaje"].ToString(),
                    Enviada = dr["Enviada"].ToString(),
                    Fecha = dr["Fecha"].ToString(),
                    Canal = dr["Canal"].ToString()
                });
            }
        }
    }
    catch (Exception ex)
    {
        throw ex;
    }

    return lista;
}


         public void InsertNotificacion(InsertNotificacionModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="UsuarioId", SqlDbType = SqlDbType.Int, Value = usuario.UsuarioId});
            parametros.Add(new SqlParameter {ParameterName="Tipo", SqlDbType = SqlDbType.NVarChar, Value = usuario.Tipo});
            parametros.Add(new SqlParameter {ParameterName="Mensaje", SqlDbType = SqlDbType.NVarChar, Value = usuario.Mensaje});
            parametros.Add(new SqlParameter {ParameterName="Canal", SqlDbType = SqlDbType.NVarChar, Value = usuario.Canal});
            

            try
            {
                dac.ExecuteNonQuery("sp_CrearNotificacion", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        
//          public void UpdateRutas(UpdateRutasModel usuario)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             ArrayList parametros = new ArrayList();

// parametros.Add(new SqlParameter {ParameterName="RutaId", SqlDbType = SqlDbType.Int, Value = usuario.RutaId});
//             parametros.Add(new SqlParameter {ParameterName="Nombre", SqlDbType = SqlDbType.NVarChar, Value = usuario.Nombre});
        

//             try
//             {
//                 dac.ExecuteNonQuery("sp_update_rutas", parametros);
//             }
//             catch(Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//                 throw ex;
//             }
//         }


//      public void DeleteRutas(int Id)
//         {
//              ConexionDataAccess dac = new ConexionDataAccess(connection);
//             ArrayList parametros = new ArrayList();

//             parametros.Add(new SqlParameter {ParameterName="Id", SqlDbType = SqlDbType.Int, Value = Id});

//             try
//             {
//                 dac.ExecuteNonQuery("sp_delete_rutas", parametros);
//             }
//             catch(Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//                 throw ex;
//             }
//         }
    }
}
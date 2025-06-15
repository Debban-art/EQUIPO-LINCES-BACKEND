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
    public class HistorialNotificacionService
    {
      private readonly string connection;

        public HistorialNotificacionService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

       public List<GetHistorialNotificacionModel> GetHistorialNotificcion()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetHistorialNotificacionModel sedes = new GetHistorialNotificacionModel();

            List<GetHistorialNotificacionModel> lista = new List<GetHistorialNotificacionModel>();
            try
            {
               
                DataSet ds = dac.Fill("sp_get_hn");
                if (ds.Tables[0].Rows.Count > 0)
                {

                  foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetHistorialNotificacionModel
                        {
                            HitorialId = int.Parse(dr["HistorialId"].ToString()),
                            Id_Notificacion = int.Parse(dr["Id_Notificacion"].ToString()),
                            EnviadaEn = dr["EnviadaEn"].ToString(),
                            Exito = int.Parse(dr["Exito"].ToString()),
                            Error = dr["Error"].ToString()
                            
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


         public void MarcarNotificacionEnviada(MarcarNotificacionEnviadaModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="NotificacionId", SqlDbType = SqlDbType.Int, Value = usuario.NotificacionId});
            parametros.Add(new SqlParameter {ParameterName="Exito", SqlDbType = SqlDbType.Int, Value = usuario.Exito});
            parametros.Add(new SqlParameter {ParameterName="Error", SqlDbType = SqlDbType.NVarChar, Value = usuario.Error});

            try
            {
                dac.ExecuteNonQuery("sp_MarcarNotificacionEnviada", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
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
    public class VisitaProgramdaService

    {
      private readonly string connection;

        public VisitaProgramdaService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<GetVisitasProgramadasModel> GetVisitasProgramadas()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetVisitasProgramadasModel sedes = new GetVisitasProgramadasModel();

            List<GetVisitasProgramadasModel> lista = new List<GetVisitasProgramadasModel>();
            try
            {
               
                DataSet ds = dac.Fill("sp_get_vp");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetVisitasProgramadasModel
                        {
                            VisitaProgramadaId = int.Parse(dr["VisitaProgramadaId"].ToString()),
                            UsuarioId = int.Parse(dr["UsuarioId"].ToString()),
                            Id_PuntoVenta = int.Parse(dr["Id_PuntoVenta"].ToString()),
                            FechaProgramada = dr["FechaProgramada"].ToString(),
                            Id_Ruta = int.Parse(dr["Id_Ruta"].ToString()),
                            NotificacionEnviada = int.Parse(dr["NotificacionEnviada"].ToString()),
                            Confirmada = int.Parse(dr["Confirmada"].ToString()),
                            
                            
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

         public void InsertVisitasProgramadas(InsertVisitasProgramadaModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="UsuarioId", SqlDbType = SqlDbType.Int, Value = usuario.UsuarioId });
            parametros.Add(new SqlParameter {ParameterName="Id_PuntoVenta", SqlDbType = SqlDbType.Int, Value = usuario.Id_PuntoVenta });
            parametros.Add(new SqlParameter {ParameterName="FechaProgramada", SqlDbType = SqlDbType.NVarChar, Value = usuario.FechaProgramada});
            parametros.Add(new SqlParameter {ParameterName="RutaId", SqlDbType = SqlDbType.Int, Value = usuario.Id_Ruta});
            parametros.Add(new SqlParameter {ParameterName="NotificacionEnviada", SqlDbType = SqlDbType.Int, Value = usuario.NotificacionEnviada});
            parametros.Add(new SqlParameter {ParameterName="Confirmada", SqlDbType = SqlDbType.Int, Value = usuario.Confirmada});

          



            try
            {
                dac.ExecuteNonQuery("sp_InsertarVisitaProgramada", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        
         public void UpdateVisitasProgramadas(UpdateVisitasProgramadasModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="VisitaId", SqlDbType = SqlDbType.Int, Value = usuario.VisitaProgramadaId});
            parametros.Add(new SqlParameter {ParameterName="FechaProgramada", SqlDbType = SqlDbType.NVarChar, Value = usuario.FechaProgramada});
            parametros.Add(new SqlParameter {ParameterName="RutaId", SqlDbType = SqlDbType.Int, Value = usuario.Id_Ruta});
          
        

            try
            {
                dac.ExecuteNonQuery("sp_ActualizarVisitaProgramada", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


     public void DeleteVisitasProgramadas(int Id)
        {
             ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="Id", SqlDbType = SqlDbType.Int, Value = Id});

            try
            {
                dac.ExecuteNonQuery("sp_delete_vp", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
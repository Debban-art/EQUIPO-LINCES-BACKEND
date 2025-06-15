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
    public class VisitasService

    {
      private readonly string connection;

        public VisitasService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<GetVisitasModel> GetVisitas()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetVisitasModel sedes = new GetVisitasModel();

            List<GetVisitasModel> lista = new List<GetVisitasModel>();
            try
            {
               
                DataSet ds = dac.Fill("sp_get_visitas");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetVisitasModel
                        {
                            VisitaId = int.Parse(dr["VisitaId"].ToString()),
                            UsuarioId = int.Parse(dr["UsuarioId"].ToString()),
                            Id_PuntoVenta = int.Parse(dr["Id_PuntoVenta"].ToString()),
                            FechaHora = dr["FechaHora"].ToString(),
                            Coordenadas = dr["Coordenadas"].ToString(),
                            Notas = dr["Notas"].ToString(),
                            VozTexto = dr["VozTexto"].ToString(),
                            Clima = dr["Clima"].ToString(),
                            AsistenciaConfirmada = int.Parse(dr["AsistenciaConfirmada"].ToString())
                            
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

         public void InsertVisitas(InsertVisitasModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="UsuarioId", SqlDbType = SqlDbType.Int, Value = usuario.UsuarioId });
            parametros.Add(new SqlParameter {ParameterName="Id_PuntoVenta", SqlDbType = SqlDbType.Int, Value = usuario.Id_PuntoVenta });
            parametros.Add(new SqlParameter {ParameterName="Coordenadas", SqlDbType = SqlDbType.NVarChar, Value = usuario.Coordenadas});
            parametros.Add(new SqlParameter {ParameterName="Notas", SqlDbType = SqlDbType.NVarChar, Value = usuario.Notas});
            parametros.Add(new SqlParameter {ParameterName="VozTexto", SqlDbType = SqlDbType.NVarChar, Value = usuario.VozTexto});
            parametros.Add(new SqlParameter {ParameterName="Clima", SqlDbType = SqlDbType.NVarChar, Value = usuario.Clima});
            parametros.Add(new SqlParameter {ParameterName="AsistenciaConfirmada", SqlDbType = SqlDbType.   Int, Value = usuario.AsistenciaConfirmada});
          



            try
            {
                dac.ExecuteNonQuery("sp_insert_visitas", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        
         public void UpdateVisitas(UpdateVisitasModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="VisitaId", SqlDbType = SqlDbType.Int, Value = usuario.VisitaId});
            parametros.Add(new SqlParameter {ParameterName="UsuarioId", SqlDbType = SqlDbType.Int, Value = usuario.UsuarioId });
            parametros.Add(new SqlParameter {ParameterName="Id_PuntoVenta", SqlDbType = SqlDbType.Int, Value = usuario.Id_PuntoVenta });
            parametros.Add(new SqlParameter {ParameterName="Coordenadas", SqlDbType = SqlDbType.NVarChar, Value = usuario.Coordenadas});
            parametros.Add(new SqlParameter {ParameterName="Notas", SqlDbType = SqlDbType.NVarChar, Value = usuario.Notas});
            parametros.Add(new SqlParameter {ParameterName="VozTexto", SqlDbType = SqlDbType.NVarChar, Value = usuario.VozTexto});
            parametros.Add(new SqlParameter {ParameterName="Clima", SqlDbType = SqlDbType.NVarChar, Value = usuario.Clima});
            parametros.Add(new SqlParameter {ParameterName="AsistenciaConfirmada", SqlDbType = SqlDbType.Int, Value = usuario.AsistenciaConfirmada});
          
        

            try
            {
                dac.ExecuteNonQuery("sp_update_visitas", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


     public void DeleteVisitas(int Id)
        {
             ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="Id", SqlDbType = SqlDbType.Int, Value = Id});

            try
            {
                dac.ExecuteNonQuery("sp_delete_visitas", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
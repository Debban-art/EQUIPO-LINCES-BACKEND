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
    public class RutasService
    {
      private readonly string connection;

        public RutasService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<GetRutasModel> GetRutas()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetRutasModel sedes = new GetRutasModel();

            List<GetRutasModel> lista = new List<GetRutasModel>();
            try
            {
               
                DataSet ds = dac.Fill("sp_get_rutas");
                if (ds.Tables[0].Rows.Count > 0)
                {

                  foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRutasModel{
                            RutaId = int.Parse(dr["RutaId"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            
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

         public void InsertRutas(InsertRutasModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="Nombre", SqlDbType = SqlDbType.NVarChar, Value = usuario.Nombre});

            try
            {
                dac.ExecuteNonQuery("sp_insert_rutas", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        
         public void UpdateRutas(UpdateRutasModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

parametros.Add(new SqlParameter {ParameterName="Id", SqlDbType = SqlDbType.Int, Value = usuario.RutaId});
            parametros.Add(new SqlParameter {ParameterName="Nombre", SqlDbType = SqlDbType.NVarChar, Value = usuario.Nombre});
        

            try
            {
                dac.ExecuteNonQuery("sp_update_rutas", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


     public void DeleteRutas(int Id)
        {
             ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="Id", SqlDbType = SqlDbType.Int, Value = Id});

            try
            {
                dac.ExecuteNonQuery("sp_delete_rutas", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
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
    public class Punto_Venta_Service
    {

        private readonly string connection;

        public Punto_Venta_Service(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<get_pv> get_pv()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            get_pv sedes = new get_pv();

            List<get_pv> lista = new List<get_pv>();
            try
            {
                DataSet ds = dac.Fill("[sp_get_pv");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new get_pv
                        {
                            id = int.Parse(dr["id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Latitud = double.Parse(dr["Latitud"].ToString()),
                            Longitud = double.Parse(dr["Longitud"].ToString()),
                            Region = dr["Region"].ToString(),
                            UltimaVisita = dr["UltimaVisita"].ToString(),
                            NPS = double.Parse(dr["NPS"].ToString()),
                            Fillfoundrate = double.Parse(dr["Fillfoundrate"].ToString()),
                            DamageRate = double.Parse(dr["DamageRate"].ToString()),
                            OutOfStock = double.Parse(dr["OutOfStock"].ToString()),
                            ComplaintResolution = double.Parse(dr["ComplaintResolution"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);
            }
            return lista;
        }

        public void insert_pv(insert_pv puntos_venta)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "Nombre", SqlDbType = SqlDbType.NVarChar, Value = puntos_venta.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "Direccion", SqlDbType = SqlDbType.NVarChar, Value = puntos_venta.Direccion });
            parametros.Add(new SqlParameter { ParameterName = "Latitud", SqlDbType = SqlDbType.Float, Value = puntos_venta.Latitud });
            parametros.Add(new SqlParameter { ParameterName = "Longitud", SqlDbType = SqlDbType.Float, Value = puntos_venta.Longitud });
            parametros.Add(new SqlParameter { ParameterName = "Region", SqlDbType = SqlDbType.NVarChar, Value = puntos_venta.Region });
            parametros.Add(new SqlParameter { ParameterName = "UltimaVisita", SqlDbType = SqlDbType.NVarChar, Value = puntos_venta.UltimaVisita });
            parametros.Add(new SqlParameter { ParameterName = "NPS", SqlDbType = SqlDbType.Float, Value = puntos_venta.NPS });
            parametros.Add(new SqlParameter { ParameterName = "Fillfoundrate", SqlDbType = SqlDbType.Float, Value = puntos_venta.Fillfoundrate });
            parametros.Add(new SqlParameter { ParameterName = "DamageRate", SqlDbType = SqlDbType.Float, Value = puntos_venta.DamageRate });
            parametros.Add(new SqlParameter { ParameterName = "OutOfStock", SqlDbType = SqlDbType.Float, Value = puntos_venta.OutOfStock });
            parametros.Add(new SqlParameter { ParameterName = "ComplaintResolution", SqlDbType = SqlDbType.Float, Value = puntos_venta.ComplaintResolution });

            try
            {
                dac.ExecuteNonQuery("sp_insert_pv", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);
            }
        }

        public void update_pv(update_pv puntos_venta)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "id", SqlDbType = SqlDbType.Int, Value = puntos_venta.id });
            parametros.Add(new SqlParameter { ParameterName = "UltimaVisita", SqlDbType = SqlDbType.NVarChar, Value = puntos_venta.UltimaVisita });
            parametros.Add(new SqlParameter { ParameterName = "NPS", SqlDbType = SqlDbType.Float, Value = puntos_venta.NPS });
            parametros.Add(new SqlParameter { ParameterName = "Fillfoundrate", SqlDbType = SqlDbType.Float, Value = puntos_venta.Fillfoundrate });
            parametros.Add(new SqlParameter { ParameterName = "DamageRate", SqlDbType = SqlDbType.Float, Value = puntos_venta.DamageRate });
            parametros.Add(new SqlParameter { ParameterName = "OutOfStock", SqlDbType = SqlDbType.Float, Value = puntos_venta.OutOfStock });
            parametros.Add(new SqlParameter { ParameterName = "ComplaintResolution", SqlDbType = SqlDbType.Float, Value = puntos_venta.ComplaintResolution });

            try
            {
                dac.ExecuteNonQuery("sp_update_pv", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);
            }
        }

      public void delete_pv(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_dpv", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);  
            }
        }
    }
}

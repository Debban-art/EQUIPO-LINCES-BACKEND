using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EQUIPO_LINCES_BACKEND.DataContext;
using EQUIPO_LINCES_BACKEND.Models;

namespace EQUIPO_LINCES_BACKEND.Services
{
    public class DetallePuntoVentaService
    {

        private readonly string connection;

        public DetallePuntoVentaService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<GetDetalleVentasModel> GetDetalleVenta()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetDetalleVentasModel sedes = new GetDetalleVentasModel();

            List<GetDetalleVentasModel> lista = new List<GetDetalleVentasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_dpv");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleVentasModel
                        {
                            RutaTiendaId = int.Parse(dr["RutaTiendaId"].ToString()),
                            RutaId = int.Parse(dr["RutaId"].ToString()),
                            Id_PuntoVenta = int.Parse(dr["Id_PuntoVenta"].ToString()),
                            Orden = int.Parse(dr["Orden"].ToString()),
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

        public void InsertDetallePuntoVenta(InsertDetalleVentaModel departamentos)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "RutaId", SqlDbType = SqlDbType.Int, Value = departamentos.RutaId});
            parametros.Add(new SqlParameter { ParameterName = "Id_PuntoVenta", SqlDbType = SqlDbType.Int, Value = departamentos.Id_PuntoVenta});
            parametros.Add(new SqlParameter { ParameterName = "Orden", SqlDbType = SqlDbType.Int, Value = departamentos.Orden});


            try
            {
                dac.ExecuteNonQuery("sp_insert_dpv", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);  
            }
        }

        public void UpdateDetalleVenta(UpdateDetalleVentaModel departamentos)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "RutaTiendaId", SqlDbType = SqlDbType.Int, Value = departamentos.Id });
            parametros.Add(new SqlParameter { ParameterName = "Orden", SqlDbType = SqlDbType.Int, Value = departamentos.Orden});

            try
            {
                dac.ExecuteNonQuery("sp_update_dpv", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);  
            }
        }

      public void DeleteDetalleVenta(int id)
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

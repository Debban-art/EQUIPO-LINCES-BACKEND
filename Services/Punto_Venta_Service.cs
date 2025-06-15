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
    public class TiendaService
    {
        private readonly string connection;

        public TiendaService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public void InsertTienda(InsertTiendaModel model)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@Nombre", model.Nombre),
                new SqlParameter("@Direccion", model.Direccion),
                new SqlParameter("@Latitud", model.Latitud ?? (object)DBNull.Value),
                new SqlParameter("@Longitud", model.Longitud ?? (object)DBNull.Value),
                new SqlParameter("@Activa", model.Activa ?? true),
                new SqlParameter("@Region", model.Region)
            };

            dac.ExecuteNonQuery("sp_insert_tienda", parametros);
        }

        public List<GetTiendaModel> GetTiendas()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<GetTiendaModel> tiendas = new List<GetTiendaModel>();
            DataSet ds = dac.Fill("sp_get_tiendas");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                tiendas.Add(new GetTiendaModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = dr["Nombre"].ToString(),
                    Direccion = dr["Direccion"].ToString(),
                    Latitud = dr["Latitud"] as double?,
                    Longitud = dr["Longitud"] as double?,
                    Activa = dr["Activa"] as bool?,
                    Region = dr["Region"].ToString(),
                    UltimaVisita = dr["UltimaVisita"] as DateTime?,
                    NPS = dr["NPS"] as decimal?,
                    Fillfoundrate = dr["Fillfoundrate"] as decimal?,
                    DamageRate = dr["Damage_rate"] as decimal?,
                    OutOfStock = dr["Out_of_stock"] as decimal?,
                    ComplaintResolution = dr["Complaint_resolution"] as decimal?
                });
            }

            return tiendas;
        }

        public GetTiendaModel GetTiendaById(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList { new SqlParameter("@Id", id) };
            DataSet ds = dac.Fill("sp_get_tienda_by_id", parametros);

            if (ds.Tables[0].Rows.Count == 0) return null;

            DataRow dr = ds.Tables[0].Rows[0];
            return new GetTiendaModel
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"].ToString(),
                Direccion = dr["Direccion"].ToString(),
                Latitud = dr["Latitud"] as double?,
                Longitud = dr["Longitud"] as double?,
                Activa = dr["Activa"] as bool?,
                Region = dr["Region"].ToString(),
                UltimaVisita = dr["UltimaVisita"] as DateTime?,
                NPS = dr["NPS"] as decimal?,
                Fillfoundrate = dr["Fillfoundrate"] as decimal?,
                DamageRate = dr["Damage_rate"] as decimal?,
                OutOfStock = dr["Out_of_stock"] as decimal?,
                ComplaintResolution = dr["Complaint_resolution"] as decimal?
            };
        }

        public void UpdateTienda(int id, InsertTiendaModel model)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", model.Nombre),
                new SqlParameter("@Direccion", model.Direccion),
                new SqlParameter("@Latitud", model.Latitud ?? (object)DBNull.Value),
                new SqlParameter("@Longitud", model.Longitud ?? (object)DBNull.Value),
                new SqlParameter("@Activa", model.Activa ?? true),
                new SqlParameter("@Region", model.Region)
            };

            dac.ExecuteNonQuery("sp_update_tienda", parametros);
        }

        public void DeleteTienda(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList { new SqlParameter("@Id", id) };
            dac.ExecuteNonQuery("sp_delete_tienda", parametros);
        }

        // Métodos simulados para imágenes y resumen
        public void UploadImagenes(int tiendaId, List<string> imagenes) { /* Simular o integrar almacenamiento */ }

        public object GetResumen(int tiendaId) => new
        {
            promedioNPS = 8.7,
            actividad = "Activa",
            sugerenciasIA = "Colocar señalización más visible, reducir tiempos de espera"
        };
    }
}

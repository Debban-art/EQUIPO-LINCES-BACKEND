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
    public class FeedbackService
    {
        private readonly string connection;

        public FeedbackService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public void InsertFeedback(InsertFeedbackModel feedback)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList {
                new SqlParameter("Id_PuntoVenta", feedback.Id_PuntoVenta),
                new SqlParameter("UsuarioId", feedback.UsuarioId),
                new SqlParameter("Tipo", feedback.Tipo),
                new SqlParameter("Descripcion", feedback.Descripcion),
                new SqlParameter("AnalisisIA", feedback.AnalisisIA)
            };

            dac.ExecuteNonQuery("sp_CrearFeedback", parametros);
        }

        public List<GetFeedbackModel> GetFeedbacksByTienda(int Id_PuntoVenta)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList {
                new SqlParameter("Id_PuntoVenta", Id_PuntoVenta)
            };

            List<GetFeedbackModel> lista = new List<GetFeedbackModel>();
            DataSet ds = dac.Fill("sp_ObtenerFeedbackPorTienda", parametros);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lista.Add(new GetFeedbackModel
                {
                    FeedbackId = Convert.ToInt32(dr["FeedbackId"]),
                    Id_PuntoVenta = Convert.ToInt32(dr["Id_PuntoVenta"]),
                    UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                    Tipo = dr["Tipo"].ToString(),
                    Descripcion = dr["Descripcion"].ToString(),
                    AnalisisIA = dr["AnalisisIA"].ToString(),
                    Fecha = dr["Fecha"].ToString()
                });
            }

            return lista;
        }

        public GetFeedbackModel GetFeedbackById(int UsuarioId)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList {
                new SqlParameter("UsuarioId", UsuarioId)
            };

            DataSet ds = dac.Fill("sp_ObtenerFeedbackPorUsuario", parametros);
            if (ds.Tables[0].Rows.Count == 0) return null;

            var dr = ds.Tables[0].Rows[0];
            return new GetFeedbackModel
            {
                FeedbackId = Convert.ToInt32(dr["FeedbackId"]),
                Id_PuntoVenta = Convert.ToInt32(dr["Id_PuntoVenta"]),
                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                Tipo = dr["Tipo"].ToString(),
                Descripcion = dr["Descripcion"].ToString(),
                AnalisisIA = dr["AnalisisIA"].ToString(),
                Fecha = dr["Fecha"].ToString()
            };
        }

      
    }
}

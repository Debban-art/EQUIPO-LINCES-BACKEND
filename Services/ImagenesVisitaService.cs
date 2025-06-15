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
    public class ImagenesVisitaService
    {
        private readonly string connection;

        public ImagenesVisitaService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public List<ObtenerImagenesPorVisita> GetImagenesPorVisita()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<ObtenerImagenesPorVisita> lista = new List<ObtenerImagenesPorVisita>();

            try
            {
                DataSet ds = dac.Fill("sp_get_imagenes_visita");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new ObtenerImagenesPorVisita
                        {
                            ImagenId = int.Parse(dr["ImagenId"].ToString()),
                            Id_Visita = int.Parse(dr["Id_Visita"].ToString()),
                            Url = dr["Url"]?.ToString(),
                            FechaSubida = dr["FechaSubida"]?.ToString(),
                            Tipo = dr["Tipo"]?.ToString(),
                            AnalisisTexto = dr["AnalisisTexto"]?.ToString(),
                            Etiquetas = dr["Etiquetas"]?.ToString()
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

        public void RegistrarImagenVisita(RegistrarImagenVisita imagen)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList
            {
                new SqlParameter { ParameterName = "Id_Visita", SqlDbType = SqlDbType.Int, Value = imagen.Id_Visita },
                new SqlParameter { ParameterName = "Url", SqlDbType = SqlDbType.NVarChar, Value = imagen.Url },
                new SqlParameter { ParameterName = "Tipo", SqlDbType = SqlDbType.NVarChar, Value = imagen.Tipo }
            };

            try
            {
                dac.ExecuteNonQuery("sp_RegistrarImagenVisita", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarAnalisisImagen(ActualizarAnalisisImagen analisis)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList
            {
                new SqlParameter { ParameterName = "ImagenId", SqlDbType = SqlDbType.Int, Value = analisis.ImagenId },
                new SqlParameter { ParameterName = "AnalisisTexto", SqlDbType = SqlDbType.NVarChar, Value = analisis.AnalisisTexto },
                new SqlParameter { ParameterName = "Etiquetas", SqlDbType = SqlDbType.NVarChar, Value = analisis.Etiquetas }
            };

            try
            {
                dac.ExecuteNonQuery("sp_actualizar_analisis_imagen", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarImagenVisita(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList
            {
                new SqlParameter { ParameterName = "ImagenId", SqlDbType = SqlDbType.Int, Value = id }
            };

            try
            {
                dac.ExecuteNonQuery("sp_eliminar_imagen_visita", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



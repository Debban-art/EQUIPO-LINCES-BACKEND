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
    public class UsuarioService
    {
        private readonly string connection;

        public UsuarioService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public void InsertUsuario(InsertUsuarioModel usuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName="Nombre", SqlDbType = SqlDbType.NVarChar, Value = usuario.Nombre});
            parametros.Add(new SqlParameter {ParameterName="ContrasenaHash", SqlDbType = SqlDbType.NVarChar, Value = usuario.ContrasenaHash});
            parametros.Add(new SqlParameter {ParameterName="Pais", SqlDbType = SqlDbType.NVarChar, Value = usuario.Pais});
            parametros.Add(new SqlParameter {ParameterName="Estado", SqlDbType = SqlDbType.NVarChar, Value = usuario.Estado});

            try
            {
                dac.ExecuteNonQuery("sp_insert_usuario", parametros);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public List<GetUsuarioModel> GetUsuarios()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<GetUsuarioModel> lista = new List<GetUsuarioModel>();

            try
            {
                DataSet ds = dac.Fill("sp_get_usuarios");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetUsuarioModel{
                            UsuarioId = int.Parse(dr["UsuarioId"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            ContrasenaHash = dr["ContrasenaHash"].ToString(),
                            Pais = dr["Pais"].ToString(),
                            Estado = dr["Estado"].ToString(),
                            Municipio = dr["Municipio"].ToString(),
                            Rol =dr["Rol"].ToString()
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return lista;
        }

        // public List<GetUsuarioModel> GetUsuariosById(int Id)
        // {
        //     ConexionDataAccess dac = new ConexionDataAccess(connection);
        //     ArrayList parametros = new ArrayList();
        //     parametros.Add(new SqlParameter {ParameterName="Id", SqlDbType = SqlDbType.Int, Value = Id});


        //     List<GetUsuarioModel> lista = new List<GetUsuarioModel>();

        //     try
        //     {
        //         DataSet ds = dac.Fill("sp_get_usuariosById", parametros);

        //         if (ds.Tables[0].Rows.Count > 0)
        //         {
        //             foreach (DataRow dr in ds.Tables[0].Rows)
        //             {
        //                 lista.Add(new GetUsuarioModel{
        //                     Id = int.Parse(dr["Id"].ToString()),
        //                     IdPersona = int.Parse(dr["id_persona"].ToString()),
        //                     Nombre = dr["nombre"].ToString(),
        //                     NombreUsuario = dr["nombre_usuario"].ToString(),
        //                     Password = dr["password"].ToString(),
        //                     IdPerfil = int.Parse(dr["id_perfil"].ToString()),
        //                     Perfil = dr["perfil"].ToString(),
        //                     FechaHora = dr["FechaHora"].ToString(),
        //                     Activo = int.Parse(dr["Activo"].ToString()),
        //                     IdUsuario = int.Parse(dr["Usuario"].ToString()),
        //                     Usuario = dr["NombreUsuario"].ToString(),
        //                 });
        //             }
        //         }
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         throw ex;
        //     }

        //     return lista;
        // }

        // public void UpdateUsuario(UpdateUsuarioModel usuario)
        // {
        //     ConexionDataAccess dac = new ConexionDataAccess(connection);
        //     ArrayList parametros = new ArrayList();

        //     parametros.Add(new SqlParameter {ParameterName="id", SqlDbType = SqlDbType.Int, Value = usuario.Id});
        //     parametros.Add(new SqlParameter {ParameterName="nombre_usuario", SqlDbType = SqlDbType.NVarChar, Value = usuario.NombreUsuario});
        //     parametros.Add(new SqlParameter {ParameterName="password", SqlDbType = SqlDbType.NVarChar, Value = usuario.Password});
        //     parametros.Add(new SqlParameter {ParameterName="id_perfil", SqlDbType = SqlDbType.Int, Value = usuario.IdPerfil});
        //     parametros.Add(new SqlParameter {ParameterName="usuario", SqlDbType = SqlDbType.Int, Value = usuario.IdUsuario});
        //     parametros.Add(new SqlParameter {ParameterName="activo", SqlDbType = SqlDbType.Int, Value = usuario.Activo});

        //     try
        //     {
        //         dac.ExecuteNonQuery("sp_update_usuario", parametros);
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         throw ex;
        //     }
        // }

        // public void DeleteUsuario(int Id)
        // {
        //      ConexionDataAccess dac = new ConexionDataAccess(connection);
        //     ArrayList parametros = new ArrayList();

        //     parametros.Add(new SqlParameter {ParameterName="id", SqlDbType = SqlDbType.Int, Value = Id});

        //     try
        //     {
        //         dac.ExecuteNonQuery("sp_delete_usuario", parametros);
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         throw ex;
        //     }
        // }




    }
}
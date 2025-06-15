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
    public class LoginService
    {

        private readonly string connection;

        public LoginService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("RETO");
        }

        public LoginUsuarioModel LoginUsuario(string nombre, string contrasenaHash)
{
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    ArrayList parametros = new ArrayList();

    parametros.Add(new SqlParameter { ParameterName = "Nombre", SqlDbType = SqlDbType.NVarChar, Value = nombre });
    parametros.Add(new SqlParameter { ParameterName = "ContrasenaHash", SqlDbType = SqlDbType.NVarChar, Value = contrasenaHash });

    try
    {
        DataSet ds = dac.Fill("sp_LoginUsuario", parametros);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            return new LoginUsuarioModel
            {
                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                Nombre = dr["Nombre"].ToString(),
                Rol = dr["Rol"].ToString()
            };
        }

        return null; // Usuario no encontrado o credenciales incorrectas
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}

    }
}
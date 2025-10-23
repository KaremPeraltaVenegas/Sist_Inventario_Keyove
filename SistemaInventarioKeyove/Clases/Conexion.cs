using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaInventarioKeyove.Clases
{
    public class Conexion
    {

        private readonly string cadenaConexion =
            ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public SqlConnection AbrirConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        public void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
                conexion.Close();
        }
    }

}
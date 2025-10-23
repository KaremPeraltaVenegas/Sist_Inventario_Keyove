using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaInventarioKeyove.Clases
{
    public class Producto
    {
        public Conexion objConexion = new Conexion();

        public DataTable ListarProductos()
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "SELECT * FROM productos";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
           

    }
}
using System;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventarioKeyove.Clases
{
    public class Producto
    {
        public Conexion objConexion = new Conexion();

        // 🔹 LISTAR TODOS LOS PRODUCTOS
        public DataTable ListarProductos()
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "SELECT * FROM productos";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 🔹 AGREGAR PRODUCTO
        public void Agregar(string nombre, string descripcion, decimal precio, int stock)
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "INSERT INTO productos (Nombre, descripcion, precio, stock) VALUES (@Nombre, @Descripcion, @Precio, @Stock)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 MODIFICAR PRODUCTO
        public int Modificar(string nombre, string descripcion, decimal precio, int stock)
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "UPDATE productos SET descripcion=@Descripcion, precio=@Precio, stock=@Stock WHERE Nombre=@Nombre";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                return cmd.ExecuteNonQuery();
            }
        }

        // 🔹 ELIMINAR PRODUCTO
        public int Eliminar(string nombre)
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "DELETE FROM productos WHERE Nombre=@Nombre";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                return cmd.ExecuteNonQuery();
            }
        }

        // 🔹 BUSCAR PRODUCTO
        public DataTable Buscar(string nombre)
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "SELECT * FROM productos WHERE Nombre LIKE @Nombre";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}

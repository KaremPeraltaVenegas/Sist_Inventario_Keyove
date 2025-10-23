using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaInventarioKeyove.Clases
{
    public class Categoria
    {
        public Conexion objConexion = new Conexion();

        public DataTable ListarCategorias()
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "SELECT Id, Nombre, Descripcion FROM Categorias";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }

        }
        public void GuardarCategoria(string nombre, string descripcion)
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void ActualizarCategoria(string id, string nombre, string descripcion)
        {
            using (SqlConnection con = objConexion.AbrirConexion())
            {
                string query = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventarioKeyove.Clases
{
    public class EntradaDetalle
    {
        private Conexion objConexion = new Conexion();

        // 🔹 Cargar todos los IDs de ingresos
        public DataTable ListarIngresos()
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    string sql = "SELECT IdIngreso FROM IngresosAlmacen ORDER BY IdIngreso DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los ingresos: " + ex.Message);
            }
        }

        // 🔹 Insertar nuevo detalle
        public void InsertarDetalle(int idIngreso, string descripcion, int cantidad, string unidad, decimal precio, string marca)
        {
            try
            {
                using (SqlConnection cn = objConexion.AbrirConexion())
                {
                    string sql = @"INSERT INTO DetalleIngreso
                                   (IdIngreso, DescripcionArticulo, Cantidad, UnidadMedida, PrecioUnit, Marca)
                                   VALUES (@IdIngreso, @Descripcion, @Cantidad, @Unidad, @Precio, @Marca)";

                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Unidad", unidad);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Marca", marca);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle: " + ex.Message);
            }
        }

        // 🔹 Listar detalles de un ingreso
        public DataTable ListarDetalles(int idIngreso)
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    string sql = @"SELECT IdDetalle,DescripcionArticulo,
                               Cantidad,
                               UnidadMedida,
                               PrecioUnit,
                               Marca
                           FROM DetalleIngreso
                           WHERE IdIngreso = @IdIngreso
                           ORDER BY IdDetalle DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.SelectCommand.Parameters.AddWithValue("@IdIngreso", idIngreso);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los detalles: " + ex.Message);
            }
        }

    }
}


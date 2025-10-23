using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventarioKeyove.Clases
{
    public class Entrada
    {
        private Conexion objConexion = new Conexion();

        // Método que devuelve los ingresos como DataTable
        public DataTable ListarEntrada()
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    string sql = "SELECT * FROM IngresosAlmacen ORDER BY IdIngreso DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt; // ← Devuelve el resultado
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las entradas: " + ex.Message);
            }
        }

        public void InsertarIngreso(string almacenDestino, string tipoMotivo, string comprobante, string nroComprobante, DateTime fechaComprobante, string rucProveedor, string razonSocial)
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    string sql = @"INSERT INTO IngresosAlmacen
                                   (AlmacenDestino, TipoMotivo, Comprobante, NroComprobante, FechaComprobante, RUCProveedor, RazonSocial)
                                   VALUES (@AlmacenDestino, @TipoMotivo, @Comprobante, @NroComprobante, @FechaComprobante, @RUCProveedor, @RazonSocial)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@AlmacenDestino", almacenDestino);
                    cmd.Parameters.AddWithValue("@TipoMotivo", tipoMotivo);
                    cmd.Parameters.AddWithValue("@Comprobante", comprobante);
                    cmd.Parameters.AddWithValue("@NroComprobante", nroComprobante);
                    cmd.Parameters.AddWithValue("@FechaComprobante", fechaComprobante);
                    cmd.Parameters.AddWithValue("@RUCProveedor", rucProveedor);
                    cmd.Parameters.AddWithValue("@RazonSocial", razonSocial);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar ingreso: " + ex.Message);
            }
        }

        public void InsertarDetalle(int idIngreso, string descripcionArticulo, decimal cantidad, string unidadMedida, decimal precioUnitario, string marca)
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    decimal subtotal = cantidad * precioUnitario; // Calculamos el subtotal

                    string sql = @"INSERT INTO DetalleIngreso
                                   (IdIngreso, DescripcionArticulo, Cantidad, UnidadMedida, PrecioUnit, SubTotal, Marca)
                                   VALUES (@IdIngreso, @DescripcionArticulo, @Cantidad, @UnidadMedida, @PrecioUnit, @SubTotal, @Marca)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);
                    cmd.Parameters.AddWithValue("@DescripcionArticulo", descripcionArticulo);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@UnidadMedida", unidadMedida);
                    cmd.Parameters.AddWithValue("@PrecioUnit", precioUnitario);
                    cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                    cmd.Parameters.AddWithValue("@Marca", marca);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle: " + ex.Message);
            }


        }
        public DataTable ListarDetalle(int idIngreso)
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    string sql = @"SELECT DescripcionArticulo, Cantidad, UnidadMedida, 
                                  PrecioUnit, SubTotal, Marca
                           FROM DetalleIngreso
                           WHERE IdIngreso = @IdIngreso";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.SelectCommand.Parameters.AddWithValue("@IdIngreso", idIngreso);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los detalles del ingreso: " + ex.Message);
            }
        }
        // 🔹 Obtener el último IdIngreso registrado
        public int ObtenerUltimoIngreso()
        {
            try
            {
                using (SqlConnection con = objConexion.AbrirConexion())
                {
                    string sql = "SELECT TOP 1 IdIngreso FROM IngresosAlmacen ORDER BY IdIngreso DESC";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    object result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último ingreso: " + ex.Message);
            }
        }

    }
}


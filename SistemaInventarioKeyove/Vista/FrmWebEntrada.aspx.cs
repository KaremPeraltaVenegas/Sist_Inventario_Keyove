using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventarioKeyove
{
    public partial class FrmWebEntrada : System.Web.UI.Page
    {
        string cadena = "Data Source=LAPTOP-32FAHBS3;Initial Catalog=ProductosBD;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MostrarIngresos();
        }

        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    string sql = @"INSERT INTO IngresosAlmacen
                                   (AlmacenDestino, TipoMotivo, Comprobante, NroComprobante, FechaComprobante, RUCProveedor, RazonSocial)
                                   VALUES (@AlmacenDestino, @TipoMotivo, @Comprobante, @NroComprobante, @FechaComprobante, @RUCProveedor, @RazonSocial)";

                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@AlmacenDestino", ddlAlmacenDestino.SelectedValue);
                    cmd.Parameters.AddWithValue("@TipoMotivo", ddlMotivo.SelectedValue);
                    cmd.Parameters.AddWithValue("@Comprobante", ddlComprobante.SelectedValue);
                    cmd.Parameters.AddWithValue("@NroComprobante", txtNroComprobante.Text);
                    cmd.Parameters.AddWithValue("@FechaComprobante", Convert.ToDateTime(txtFechaComprobante.Text));
                    cmd.Parameters.AddWithValue("@RUCProveedor", txtRUC.Text);
                    cmd.Parameters.AddWithValue("@RazonSocial", txtRazonSocial.Text);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.Text = "✅ Ingreso registrado correctamente";
                MostrarIngresos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error: " + ex.Message;
            }
        }

        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                int idIngreso = ObtenerUltimoIngreso();

                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    string sql = @"INSERT INTO DetalleIngreso
                                   (IdIngreso, DescripcionArticulo, Cantidad, UnidadMedida, PrecioUnit, Marca)
                                   VALUES (@IdIngreso, @DescripcionArticulo, @Cantidad, @UnidadMedida, @PrecioUnit, @Marca)";

                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);
                    cmd.Parameters.AddWithValue("@DescripcionArticulo", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@Cantidad", Convert.ToDecimal(txtCantidad.Text));
                    cmd.Parameters.AddWithValue("@UnidadMedida", txtUnidad.Text);
                    cmd.Parameters.AddWithValue("@PrecioUnit", Convert.ToDecimal(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MostrarDetalles(idIngreso);
                LimpiarDetalle();
                lblMensaje.Text = "✅ Detalle agregado correctamente";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al guardar detalle: " + ex.Message;
            }
        }

        private void MostrarIngresos()
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string sql = "SELECT IdIngreso, AlmacenDestino, TipoMotivo, Comprobante, NroComprobante, FechaComprobante, RUCProveedor, RazonSocial FROM IngresosAlmacen ORDER BY IdIngreso DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvIngresos.DataSource = dt;
                gvIngresos.DataBind();
            }
        }

        private void MostrarDetalles(int idIngreso)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string sql = "SELECT DescripcionArticulo, Cantidad, UnidadMedida, PrecioUnit, SubTotal, Marca FROM DetalleIngreso WHERE IdIngreso = @IdIngreso";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@IdIngreso", idIngreso);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvDetalles.DataSource = dt;
                gvDetalles.DataBind();
            }
        }

        private int ObtenerUltimoIngreso()
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string sql = "SELECT TOP 1 IdIngreso FROM IngresosAlmacen ORDER BY IdIngreso DESC";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void LimpiarDetalle()
        {
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtUnidad.Text = "";
            txtPrecio.Text = "";
            txtMarca.Text = "";
        }
    }
}

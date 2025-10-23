using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaInventarioKeyove.Vista
{
    public partial class FrmWebEntradaDetalle : System.Web.UI.Page
    {

        string cadena = "Data Source=DESKTOP-NC03344\\MSSQLSERVER01;Initial Catalog=ProductosBD;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIngresos();
            }
        }

        // 🔹 Carga los IDs de ingresos disponibles
        private void CargarIngresos()
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT IdIngreso FROM IngresosAlmacen ORDER BY IdIngreso DESC", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                ddlIngreso.DataSource = dr;
                ddlIngreso.DataTextField = "IdIngreso";
                ddlIngreso.DataValueField = "IdIngreso";
                ddlIngreso.DataBind();
            }

            MostrarDetalles(); // carga los detalles del primer ingreso
        }

        // 🔹 Botón "Agregar Detalle"
        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    string sql = @"INSERT INTO DetalleIngreso 
                                   (IdIngreso, DescripcionArticulo, Cantidad, UnidadMedida, PrecioUnit, Marca)
                                   VALUES (@IdIngreso, @Descripcion, @Cantidad, @Unidad, @Precio, @Marca)";

                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@IdIngreso", ddlIngreso.SelectedValue);
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                    cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
                    cmd.Parameters.AddWithValue("@Unidad", ddlUnidad.SelectedValue);
                    cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@Marca", txtMarca.Text.Trim());

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "✅ Detalle agregado correctamente.";

                LimpiarCampos();
                MostrarDetalles();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "❌ Error: " + ex.Message;
            }
        }

        // 🔹 Muestra los detalles del ingreso seleccionado
        private void MostrarDetalles()
        {
            if (ddlIngreso.Items.Count == 0) return;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string sql = "SELECT IdDetalle, DescripcionArticulo, Cantidad, UnidadMedida, PrecioUnit, (Cantidad * PrecioUnit) AS SubTotal, Marca FROM DetalleIngreso WHERE IdIngreso = @Id";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", ddlIngreso.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvDetalle.DataSource = dt;
                gvDetalle.DataBind();
            }
        }

        // 🔹 Limpia los campos después de agregar
        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtMarca.Text = "";
        }

        // 🔹 Cuando cambia el ID de ingreso
        protected void ddlIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }
    }
}

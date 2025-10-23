using System;
using System.Data;
using SistemaInventarioKeyove.Clases;

namespace SistemaInventarioKeyove.Vista
{
    public partial class FrmWebEntradaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarIngresos();
        }

        // 🔹 Cargar IDs de ingresos
        private void CargarIngresos()
        {
            try
            {
                EntradaDetalle obj = new EntradaDetalle();
                DataTable dt = obj.ListarIngresos();

                ddlIngreso.DataSource = dt;
                ddlIngreso.DataTextField = "IdIngreso";
                ddlIngreso.DataValueField = "IdIngreso";
                ddlIngreso.DataBind();

                MostrarDetalles(); // mostrar el primero
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al cargar ingresos: " + ex.Message;
            }
        }

        // 🔹 Botón "Agregar Detalle"
        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                int idIngreso = Convert.ToInt32(ddlIngreso.SelectedValue);
                string descripcion = txtDescripcion.Text.Trim();
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string unidad = ddlUnidad.SelectedValue;
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                string marca = txtMarca.Text.Trim();

                EntradaDetalle obj = new EntradaDetalle();
                obj.InsertarDetalle(idIngreso, descripcion, cantidad, unidad, precio, marca);

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "✅ Detalle agregado correctamente.";

                LimpiarCampos();
                MostrarDetalles();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "❌ Error al agregar detalle: " + ex.Message;
            }
        }

        // 🔹 Mostrar los detalles del ingreso seleccionado
        private void MostrarDetalles()
        {
            try
            {
                if (ddlIngreso.Items.Count == 0) return;

                int idIngreso = Convert.ToInt32(ddlIngreso.SelectedValue);
                EntradaDetalle obj = new EntradaDetalle();
                DataTable dt = obj.ListarDetalles(idIngreso);

                gvDetalle.DataSource = dt;
                gvDetalle.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al mostrar detalles: " + ex.Message;
            }
        }

        // 🔹 Cuando cambia el ingreso seleccionado
        protected void ddlIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }

        // 🔹 Limpiar campos después de agregar
        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtMarca.Text = "";
        }
    }
}


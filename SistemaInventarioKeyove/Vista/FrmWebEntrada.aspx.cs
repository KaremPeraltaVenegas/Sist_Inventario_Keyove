using System;
using System.Data;
using System.Data.SqlClient;
using SistemaInventarioKeyove.Clases;

namespace SistemaInventarioKeyove
{
    public partial class FrmWebEntrada : System.Web.UI.Page
    {
        Entrada objEntrada = new Entrada();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MostrarIngresos();
        }

        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            try
            {
                Entrada objEntrada = new Entrada();

                objEntrada.InsertarIngreso(
                    ddlAlmacenDestino.SelectedValue,
                    ddlMotivo.SelectedValue,
                    ddlComprobante.SelectedValue,
                    txtNroComprobante.Text,
                    Convert.ToDateTime(txtFechaComprobante.Text),
                    txtRUC.Text,
                    txtRazonSocial.Text
                );

                lblMensaje.Text = "✅ Ingreso registrado correctamente";
                MostrarIngresos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al registrar ingreso: " + ex.Message;
            }
        }

        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                int idIngreso = ObtenerUltimoIngreso();

                Entrada objEntrada = new Entrada();
                objEntrada.InsertarDetalle(
                    idIngreso,
                    txtDescripcion.Text,
                    Convert.ToDecimal(txtCantidad.Text),
                    txtUnidad.Text,
                    Convert.ToDecimal(txtPrecio.Text),
                    txtMarca.Text
                );

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
            try
            {
                Entrada objEntrada = new Entrada();
                DataTable dt = objEntrada.ListarEntrada();

                gvIngresos.DataSource = dt;
                gvIngresos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al mostrar ingresos: " + ex.Message;
            }
        }
        private void MostrarDetalles(int idIngreso)
        {
            try
            {
                Entrada objEntrada = new Entrada();
                DataTable dt = objEntrada.ListarDetalle(idIngreso);

                gvDetalles.DataSource = dt;
                gvDetalles.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al mostrar detalles: " + ex.Message;
            }
        }
        private int ObtenerUltimoIngreso()
        {
            try
            {
                Entrada objEntrada = new Entrada();
                return objEntrada.ObtenerUltimoIngreso();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al obtener el último ingreso: " + ex.Message;
                return 0;
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

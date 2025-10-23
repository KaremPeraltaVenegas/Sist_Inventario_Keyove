using System;
using System.Data;
using SistemaInventarioKeyove.Clases;

namespace SistemaInventarioKeyove
{
    public partial class FrmProducto : System.Web.UI.Page
    {
        Producto objProducto = new Producto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarProductos();
        }

        // 🔹 AGREGAR
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                objProducto.Agregar(
                    txtNombre.Text,
                    txtDescripcion.Text,
                    Convert.ToDecimal(txtPrecio.Text),
                    Convert.ToInt32(txtStock.Text)
                );

                CargarProductos();
                LimpiarCampos();
                Response.Write("<script>alert('✅ Producto agregado correctamente');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al agregar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 MODIFICAR
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int filas = objProducto.Modificar(
                    txtNombreMod.Text,
                    txtDescripcionMod.Text,
                    Convert.ToDecimal(txtPrecioMod.Text),
                    Convert.ToInt32(txtStockMod.Text)
                );

                if (filas > 0)
                    Response.Write("<script>alert('✅ Producto modificado correctamente');</script>");
                else
                    Response.Write("<script>alert('⚠️ No se encontró el producto con ese nombre');</script>");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al modificar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 ELIMINAR
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int filas = objProducto.Eliminar(txtNombreDel.Text);

                if (filas > 0)
                    Response.Write("<script>alert('✅ Producto eliminado correctamente');</script>");
                else
                    Response.Write("<script>alert('⚠️ No se encontró el producto con ese nombre');</script>");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al eliminar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 BUSCAR
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = objProducto.Buscar(txtBuscar.Text);
                gvProductos.DataSource = dt;
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al buscar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 CARGAR TODOS
        private void CargarProductos()
        {
            try
            {
                gvProductos.DataSource = objProducto.ListarProductos();
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al cargar productos: " + ex.Message + "');</script>");
            }
        }

        // 🔹 LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtNombreMod.Text = "";
            txtDescripcionMod.Text = "";
            txtPrecioMod.Text = "";
            txtStockMod.Text = "";
            txtNombreDel.Text = "";
            txtBuscar.Text = "";
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient; // 🔹 NECESARIO para usar SQL Server
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SistemaInventarioKeyove.Clases;

namespace SistemaInventarioKeyove
{
    public partial class FrmProducto : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarProductos();
        }

        // 🔹 AGREGAR PRODUCTO
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO productos (Nombre, descripcion, precio, stock) VALUES (@Nombre, @Descripcion, @Precio, @Stock)", con);

                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));

                    cmd.ExecuteNonQuery();
                }

                CargarProductos();
                LimpiarCampos();
                Response.Write("<script>alert('✅ Producto agregado correctamente');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al agregar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 MODIFICAR PRODUCTO POR NOMBRE
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE productos SET descripcion=@Descripcion, precio=@Precio, stock=@Stock WHERE Nombre=@Nombre", con);

                    cmd.Parameters.AddWithValue("@Nombre", txtNombreMod.Text);
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcionMod.Text);
                    cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecioMod.Text));
                    cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStockMod.Text));

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        Response.Write("<script>alert('✅ Producto modificado correctamente');</script>");
                    else
                        Response.Write("<script>alert('⚠️ No se encontró el producto con ese nombre');</script>");
                }

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al modificar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 ELIMINAR PRODUCTO POR NOMBRE
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM productos WHERE Nombre=@Nombre", con);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombreDel.Text);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        Response.Write("<script>alert('✅ Producto eliminado correctamente');</script>");
                    else
                        Response.Write("<script>alert('⚠️ No se encontró el producto con ese nombre');</script>");
                }

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al eliminar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 BUSCAR PRODUCTO POR NOMBRE
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM productos WHERE Nombre LIKE @Nombre", con);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", "%" + txtBuscar.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvProductos.DataSource = dt;
                    gvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al buscar: " + ex.Message + "');</script>");
            }
        }

        // 🔹 CARGAR TODOS LOS PRODUCTOS
        private void CargarProductos()
        {
            try
            {

                Producto objProducto = new Producto();
                objProducto.ListarProductos();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al cargar productos: " + ex.Message + "');</script>");
            }
        }

        // 🔹 LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            // Campos de agregar
            if (this.FindControl("txtNombre") != null) txtNombre.Text = "";
            if (this.FindControl("txtDescripcion") != null) txtDescripcion.Text = "";
            if (this.FindControl("txtPrecio") != null) txtPrecio.Text = "";
            if (this.FindControl("txtStock") != null) txtStock.Text = "";

            // Campos de modificar
            if (this.FindControl("txtNombreMod") != null) txtNombreMod.Text = "";
            if (this.FindControl("txtDescripcionMod") != null) txtDescripcionMod.Text = "";
            if (this.FindControl("txtPrecioMod") != null) txtPrecioMod.Text = "";
            if (this.FindControl("txtStockMod") != null) txtStockMod.Text = "";

            // Campo eliminar
            if (this.FindControl("txtNombreDel") != null) txtNombreDel.Text = "";

            // Campo buscar
            if (this.FindControl("txtBuscar") != null) txtBuscar.Text = "";
        }
    }
}


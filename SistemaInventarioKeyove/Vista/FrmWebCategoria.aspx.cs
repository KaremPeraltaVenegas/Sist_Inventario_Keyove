using SistemaInventarioKeyove.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaInventarioKeyove
{
    public partial class FrmWebCategoria : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ListarCategorias();
        }

        private void ListarCategorias()
        {
            try
            {
                Categoria objCategoria = new Categoria();

                GridViewCategorias.DataSource = objCategoria.ListarCategorias(); 
                GridViewCategorias.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('❌ Error al cargar categorias: " + ex.Message + "');</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria objCategoria = new Categoria();
            objCategoria.GuardarCategoria(txtNombre.Text, txtDescripcion.Text);

            ListarCategorias();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Categoria objCategoria = new Categoria();
            objCategoria.ActualizarCategoria(IdCategoria.ClientID, txtNombre.Text, txtDescripcion.Text);

            ListarCategorias();
        }
    }
}
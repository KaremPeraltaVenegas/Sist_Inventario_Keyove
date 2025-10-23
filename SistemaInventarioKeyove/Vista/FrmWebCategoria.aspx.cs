using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaInventarioKeyove
{
    public partial class FrmWebCategoria : System.Web.UI.Page
    {
        string conexionString = "Data Source=DESKTOP-NC03344\\MSSQLSERVER01;Initial Catalog=ProductosBD;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCategorias();
        }

        private void CargarCategorias()
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string query = "SELECT Id, Nombre, Descripcion FROM Categorias";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewCategorias.DataSource = dt;
                GridViewCategorias.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string query = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }

            CargarCategorias();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string query = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", hfIdCategoria.Value);
                cmd.Parameters.AddWithValue("@Nombre", txtEditarNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtEditarDescripcion.Text);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }

            CargarCategorias();
        }
    }
}
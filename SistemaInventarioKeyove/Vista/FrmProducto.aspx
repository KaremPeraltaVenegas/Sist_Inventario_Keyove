<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmProducto.aspx.cs" Inherits="SistemaInventarioKeyove.FrmProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBody" runat="server">
    
    
        <div class="container">
            <h2>Gestión de Productos</h2>

            <div class="buttons">
                <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalAgregar"> Agregar</button>
                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalModificar"> Modificar</button>
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#modalEliminar"> Eliminar</button>
            </div>

            <div class="search-box">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control d-inline-block w-50" placeholder=" Buscar producto..."></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary ms-2" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>

            <div class="grid mt-3">
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="true"
                    CssClass="table table-striped table-hover align-middle"
                    HeaderStyle-BackColor="#007bff" HeaderStyle-ForeColor="white"
                    GridLines="None" BorderStyle="None">
                </asp:GridView>
            </div>
        </div>

        <!-- ✅ MODAL AGREGAR -->
        <div class="modal fade" id="modalAgregar" tabindex="-1" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header bg-primary text-white">
                <h5 class="modal-title">Agregar Producto</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
              </div>
              <div class="modal-body">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Precio" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Stock" TextMode="Number"></asp:TextBox>
              </div>
              <div class="modal-footer">
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnAgregar_Click" />
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
              </div>
            </div>
          </div>
        </div>

        <!-- ✅ MODAL MODIFICAR -->
        <div class="modal fade" id="modalModificar" tabindex="-1" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header bg-warning text-dark">
                <h5 class="modal-title">Modificar Producto</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
              </div>
              <div class="modal-body">
                <asp:TextBox ID="txtNombreMod" runat="server" CssClass="form-control" placeholder="Nombre del producto a modificar"></asp:TextBox>
                <asp:TextBox ID="txtDescripcionMod" runat="server" CssClass="form-control" placeholder="Nueva descripción"></asp:TextBox>
                <asp:TextBox ID="txtPrecioMod" runat="server" CssClass="form-control" placeholder="Nuevo precio" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="txtStockMod" runat="server" CssClass="form-control" placeholder="Nuevo stock" TextMode="Number"></asp:TextBox>
              </div>
              <div class="modal-footer">
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Actualizar" OnClick="btnModificar_Click" />
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
              </div>
            </div>
          </div>
        </div>

        <!-- ✅ MODAL ELIMINAR -->
        <div class="modal fade" id="modalEliminar" tabindex="-1" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header bg-danger text-white">
                <h5 class="modal-title">Eliminar Producto</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
              </div>
              <div class="modal-body">
                <asp:TextBox ID="txtNombreDel" runat="server" CssClass="form-control" placeholder="Nombre del producto a eliminar"></asp:TextBox>
                <p class="text-danger mt-3">⚠️ ¿Estás segura de eliminar este producto?</p>
              </div>
              <div class="modal-footer">
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
              </div>
            </div>
          </div>
        </div>

        <div class="footer text-center mt-4">
            © 2025 Sistema de Gestión de Productos | Creado por Daniela 💻
        </div>

</asp:Content>

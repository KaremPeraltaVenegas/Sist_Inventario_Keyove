<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmProducto.aspx.cs" Inherits="SistemaInventarioKeyove.FrmProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBody" runat="server">

    <div class="container my-4">
        <h2 class="mb-4">Gestión de Productos</h2>

        <!-- Sección de búsqueda -->
        <div class="d-flex mb-4">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2" placeholder="Buscar producto..."></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-outline-primary" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>

        <!-- Botones de acciones -->
        <div class="d-flex flex-wrap gap-3 mb-4">
            <button type="button" class="btn btn-success btn-lg" data-bs-toggle="modal" data-bs-target="#modalAgregar">
                <i class="bi bi-plus-circle"></i>Agregar
            </button>
            <button type="button" class="btn btn-warning btn-lg" data-bs-toggle="modal" data-bs-target="#modalModificar">
                <i class="bi bi-pencil-square"></i>Modificar
            </button>
            <button type="button" class="btn btn-danger btn-lg" data-bs-toggle="modal" data-bs-target="#modalEliminar">
                <i class="bi bi-trash"></i>Eliminar
            </button>
        </div>

        <!-- Grid con lista de productos -->
        <div class="table-responsive">
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmWebEntradaDetalle.aspx.cs" Inherits="SistemaInventarioKeyove.Vista.FrmWebEntradaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoHeader" runat="server">
    <style>
        body { font-family: Segoe UI, sans-serif; background-color: #f4f4f4; }
        .container { width: 90%; max-width: 900px; margin: 30px auto; background: #fff; padding: 25px; border-radius: 10px; box-shadow: 0 0 10px #ccc; }
        .group { margin-bottom: 15px; display: flex; align-items: center; }
        label { width: 180px; font-weight: bold; }
        input, select { flex: 1; padding: 6px; border: 1px solid #ccc; border-radius: 5px; }
        .btn { background: #007bff; color: white; border: none; padding: 8px 15px; border-radius: 5px; cursor: pointer; }
        .btn:hover { background: #0056b3; }
        hr { margin: 20px 0; }
        .tabla-grid { border-collapse: collapse; width: 100%; text-align: center; }
        .tabla-grid th { background-color: #007bff; color: white; padding: 8px; }
        .tabla-grid td { padding: 6px; border: 1px solid #ccc; }
        .tabla-grid tr:hover { background-color: #eaf3ff; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBody" runat="server">
     <div class="container">
        <h2>Detalle de Ingreso a Almacén</h2>

        <div class="group">
            <label>ID Ingreso (Encabezado):</label>
            <asp:DropDownList ID="ddlIngreso" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="group">
            <label>Descripción del Artículo:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
        </div>

        <div class="group">
            <label>Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control" />
        </div>

        <div class="group">
            <label>Unidad de Medida:</label>
            <asp:DropDownList ID="ddlUnidad" runat="server" CssClass="form-control">
                <asp:ListItem>UND</asp:ListItem>
                <asp:ListItem>CAJA</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="group">
            <label>Precio Unitario:</label>
            <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" CssClass="form-control" />
        </div>

        <div class="group">
            <label>Marca:</label>
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
        </div>

        <div class="group">
            <asp:Button ID="btnAgregarDetalle" runat="server" Text="Agregar Detalle" CssClass="btn btn-primary" OnClick="btnAgregarDetalle_Click" />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" CssClass="ms-3" />
        </div>

        <hr />
        <h3>Detalles del Ingreso</h3>

        <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CssClass="tabla-grid">
            <Columns>
                <asp:BoundField DataField="IdDetalle" HeaderText="ID Detalle" />
                <asp:BoundField DataField="DescripcionArticulo" HeaderText="Artículo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cant." />
                <asp:BoundField DataField="UnidadMedida" HeaderText="U.Med." />
                <asp:BoundField DataField="PrecioUnit" HeaderText="P.Unit" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

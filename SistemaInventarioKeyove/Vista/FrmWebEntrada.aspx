<%@ Page Title="Registro de Ingresos" Language="C#" MasterPageFile="~/Main.Master"AutoEventWireup="true" CodeBehind="FrmWebEntrada.aspx.cs"Inherits="SistemaInventarioKeyove.FrmWebEntrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoHeader" runat="server">
    <style>
        body { font-family: Segoe UI, sans-serif; background-color: #f5f5f5; }
        .container { width: 850px; margin: 30px auto; background: #fff; padding: 25px; border-radius: 10px; box-shadow: 0 0 10px #ccc; }
        h2, h3 { color: #333; }
        .group { margin-bottom: 15px; display: flex; align-items: center; }
        label { width: 200px; font-weight: bold; }
        input, select { flex: 1; padding: 6px; border: 1px solid #ccc; border-radius: 5px; }
        .btn { background: #007bff; color: white; border: none; padding: 8px 15px; border-radius: 5px; cursor: pointer; }
        .btn:hover { background: #0056b3; }
        hr { margin: 25px 0; border: none; border-top: 1px solid #ddd; }
        .tabla { width: 100%; border-collapse: collapse; text-align: center; margin-top: 10px; }
        .tabla th, .tabla td { border: 1px solid #ccc; padding: 8px; }
        .tabla th { background: #007bff; color: white; }
        .tabla tr:hover { background: #eef5ff; }
        .msg { font-weight: bold; display: block; margin-top: 10px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBody" runat="server">
        <div class="container">
            <h2>Registro de Ingreso al Almacén</h2>

            <!-- ENCABEZADO -->
            <div class="group">
                <label>Almacén destino:</label>
                <asp:DropDownList ID="ddlAlmacenDestino" runat="server" />
            </div>

            <div class="group">
                <label>Tipo de motivo:</label>
                <asp:DropDownList ID="ddlMotivo" runat="server">
                    <asp:ListItem>COMPRA</asp:ListItem>
                    <asp:ListItem>DEVOLUCIÓN</asp:ListItem>
                    <asp:ListItem>DONACIÓN</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="group">
                <label>Tipo de comprobante:</label>
                <asp:DropDownList ID="ddlComprobante" runat="server">
                    <asp:ListItem>FACTURA</asp:ListItem>
                    <asp:ListItem>BOLETA</asp:ListItem>
                    <asp:ListItem>GUIA</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="group">
                <label>N° de comprobante:</label>
                <asp:TextBox ID="txtNroComprobante" runat="server" />
            </div>

            <div class="group">
                <label>Fecha de comprobante:</label>
                <asp:TextBox ID="txtFechaComprobante" runat="server" TextMode="Date" />
            </div>

            <div class="group">
                <label>RUC proveedor:</label>
                <asp:TextBox ID="txtRUC" runat="server" />
            </div>

            <div class="group">
                <label>Razón social:</label>
                <asp:TextBox ID="txtRazonSocial" runat="server" />
            </div>

            <div class="group">
                <asp:Button ID="btnAgregarItem" runat="server" Text="Agregar Encabezado" CssClass="btn" OnClick="btnAgregarItem_Click" />
            </div>

            <hr />

            <!-- DETALLE -->
            <h3>Detalle del Ingreso</h3>

            <div class="group">
                <label>Descripción del artículo:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" />
            </div>

            <div class="group">
                <label>Cantidad:</label>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" />
            </div>

            <div class="group">
                <label>Unidad de medida:</label>
                <asp:TextBox ID="txtUnidad" runat="server" />
            </div>

            <div class="group">
                <label>Precio unitario:</label>
                <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" />
            </div>

            <div class="group">
                <label>Marca:</label>
                <asp:TextBox ID="txtMarca" runat="server" />
            </div>

            <div class="group">
                <asp:Button ID="btnGuardarDetalle" runat="server" Text="Agregar Detalle" CssClass="btn" OnClick="btnGuardarDetalle_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="msg" ForeColor="Green" />

            <hr />

            <!-- TABLAS -->
            <h3>Ingresos Registrados</h3>
            <asp:GridView ID="gvIngresos" runat="server" CssClass="tabla" AutoGenerateColumns="true" />

            <h3>Detalles del Ingreso</h3>
            <asp:GridView ID="gvDetalles" runat="server" CssClass="tabla" AutoGenerateColumns="true" />
        </div>
</asp:Content>

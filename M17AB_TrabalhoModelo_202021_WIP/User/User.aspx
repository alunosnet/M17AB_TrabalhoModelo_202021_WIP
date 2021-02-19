<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.User.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>User dashboard</h2>
    <div runat="server" id="divPerfil">
        Nome:<asp:Label ID="lbNome" CssClass="form-control" runat="server" Text="Label"></asp:Label>
        <br />Morada:<asp:Label CssClass="form-control" ID="lbMorada" runat="server" Text="Label"></asp:Label>
        <br />Nif:<asp:Label CssClass="form-control" ID="lbNif" runat="server" Text="Label"></asp:Label>
        <br /><asp:Button OnClick="btEditar_Click" CssClass="btn btn-danger" ID="btEditar" runat="server" Text="Editar" />
    </div>
    <div runat="server" id="divEditar">
        Nome:<asp:TextBox CssClass="form-control" ID="tbNome" runat="server"></asp:TextBox>
        <br />Morada:<asp:TextBox CssClass="form-control" ID="tbMorada" runat="server"></asp:TextBox>
        <br />Nif:<asp:TextBox CssClass="form-control" ID="tbNif" runat="server"></asp:TextBox>
        <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
        <asp:Button OnClick="btGuardar_Click" CssClass="btn btn-danger" ID="btGuardar" runat="server" Text="Guardar" />
        <asp:Button OnClick="btCancelar_Click" CssClass="btn btn-info" ID="btCancelar" runat="server" Text="Cancelar" />
    </div>
</asp:Content>
